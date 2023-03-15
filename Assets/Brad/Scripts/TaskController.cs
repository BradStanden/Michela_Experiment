using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class TaskController : MonoBehaviour
{

    public List<int> TrialList;
    List<int> tempList;
    public int counter;
    public int state; //1=trial select, 2=fixation, 3= primer, 4 = condition

    public GameObject ball;
    public GameObject fixi;
    public GameObject RightController;

    public Material neutral;
    public Material goHand;
    public Material noGoHand;
    public Material fixation;
    public Color noGoCol;
    public Color goCol;

    public Material curSkybox;
    public Color curColor;

    public float timer;

    public Renderer ballRend;

    public bool doPress;
    public bool pressed;
    public bool finish;

    public bool triggerValue;

    private InputDevice rightController;

    public TextMeshProUGUI correct;
    public GameObject Instructions;

    public GameObject Score;
    public TextMeshProUGUI Val1;
    public TextMeshProUGUI Val2;
    public TextMeshProUGUI Val3;
    public TextMeshProUGUI Val4;
    public TextMeshProUGUI Val5;
    public TextMeshProUGUI ValScore;
    public XRInteractorLineVisual line;




    void Awake()
    {
        //make script to control this by button
        GlobalVars.xTrials = 16;
        rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        tempList = new List<int> { 0 };
        TrialList = new List<int> { 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3};
        finish = false;

        if (GlobalVars.xTrials == 16)
        {
            tempList.AddRange(TrialList);
            TrialList = tempList;

        }

        if (GlobalVars.xTrials == 32)
        {
            tempList.AddRange(TrialList);
            tempList.AddRange(TrialList);
            TrialList = tempList;
        }

        if (GlobalVars.xTrials == 48)
        {
            tempList.AddRange(TrialList);
            tempList.AddRange(TrialList);
            tempList.AddRange(TrialList);
            TrialList = tempList;
        }
        goCol = Color.blue;
        noGoCol = new Color(1.0f, 0.34f, 0.0f);
        ballRend = ball.GetComponent<Renderer>();
        Instructions.SetActive(true);
        
        line = RightController.GetComponent<XRInteractorLineVisual>();
        line.lineLength = 10;

        GlobalVars.totalRT = 0;
        GlobalVars.congRT = 0;
        GlobalVars.incongRT = 0;
        GlobalVars.imiError = 0;
        GlobalVars.correctCount = 0;
        counter = 0;
        timer = 0;
        GlobalVars.xType = TrialList[counter];


    }

    void Update()
    {
        timer += Time.deltaTime;


        if (state == 2)
        {
            if (timer >= 2f)
            {
                //primerDisplay();
                TrialDisplay();
            }
        }
        if (state == 3)
        {
            if (timer >= 1f)
            {
                TrialDisplay();
            }
        }

        if (state == 4)
        {
            if (timer >= 2)
            {
                if (doPress == true)
                {
                    GlobalVars.xCorrect = false;
                }
                else 
                { 
                    GlobalVars.xCorrect = true;
                    GlobalVars.correctCount += 1;

                }
                //SaveIntoCSV();
                TrialSelect();
            }


            if (rightController.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                pressed = true;
                GlobalVars.xRT = timer;

                if (doPress == true)
                {
                    GlobalVars.xCorrect = true;
                    GlobalVars.correctCount += 1;
                    if (GlobalVars.xType == 0)
                    {
                        GlobalVars.totalRT += GlobalVars.xRT;
                        GlobalVars.congRT += GlobalVars.xRT;
                    }
                    if (GlobalVars.xType == 2)
                    {
                        GlobalVars.totalRT += GlobalVars.xRT;
                        GlobalVars.incongRT += GlobalVars.xRT;
                    }
                }
                else 
                {                     
                    GlobalVars.xCorrect = false; 
                    if (GlobalVars.xType == 3)
                    {
                        GlobalVars.imiError += 1;
                    }
                
                }
                //SaveIntoCSV();
                TrialSelect();

            }
        }


    }

    public void StartExperiment()
    {
        Instructions.SetActive(false);
        line.lineLength = 0;
        TrialSelect();
    }
    public void TrialSelect()
    {
        TrialList.RemoveAt(counter);

        if (TrialList.Count != 0)
        {
            counter = Random.Range(0, TrialList.Count);
        }

        else 
        {
           
            EndExperiment(); 
        }

        pressed = false;
        fixi.SetActive(false);
        ball.SetActive(false);
        timer = 0;
        GlobalVars.xRT = 0;
        state = 1;

        

        GlobalVars.xType = TrialList[counter];

        if (GlobalVars.xType == 0)//ConGo
        {
            curSkybox = goHand;
            curColor = goCol;
            doPress = true;
        }
        if (GlobalVars.xType == 1)//ConNoGo
        {
            curSkybox = noGoHand;
            curColor = noGoCol;
            doPress = false;
        }
        if (GlobalVars.xType == 2)//InconGo
        {
            curSkybox = noGoHand;
            curColor = goCol;
            doPress = true;
        }
        if (GlobalVars.xType == 3)//InconNoGo
        {
            curSkybox = goHand;
            curColor = noGoCol;
            doPress = false;
        }
        FixationDisplay();
    }

    void FixationDisplay()
    {

        timer = 0;
        state = 2;
        RenderSettings.skybox = fixation;
        fixi.SetActive(true);
        ball.SetActive(false);
    }

    void primerDisplay()
    {
        timer = 0;
        ballRend.material.color = Color.grey;
        fixi.SetActive(false);
        ball.SetActive(true);
        state = 3;
        RenderSettings.skybox = neutral;
    }

    void TrialDisplay()
    {
        fixi.SetActive(false);
        ball.SetActive(true);
        timer = 0;
        state = 4;
        RenderSettings.skybox = curSkybox;
        ballRend.material.color = curColor;

        

    }

    public void EndExperiment()
    {
    
        line.lineLength = 10;
        Score.SetActive(true);
        float correctPercentage = ((GlobalVars.correctCount/GlobalVars.xTrials)*100);
        Val1.text = ("Your average reaction time was: " + (GlobalVars.totalRT / (GlobalVars.xTrials/2)).ToString("0.00000"));
        //Val2.text = ("Your correct response percentage was: " + (((GlobalVars.correctCount / GlobalVars.xTrials)*100).ToString())+ "%");
        Val2.text = ("Your correct response percentage was: " + correctPercentage.ToString("#.00") + "%");
        Val3.text = ("Your made " + GlobalVars.imiError + " Imitation errors");
        Val4.text = ("Your average imitation reaction time was: " + (GlobalVars.congRT / (GlobalVars.xTrials/4)).ToString("0.00000"));
        Val5.text = ("Your average anti-imitation reaction time was: " + (GlobalVars.incongRT / (GlobalVars.xTrials / 4)).ToString("0.00000"));
        ValScore.text = ("Congratulations!!! Your Performance score is: " + (((GlobalVars.totalRT / (GlobalVars.xTrials / 2))*(1 + (1 - (correctPercentage/100)))).ToString("0.00000")));

    }



    void SaveIntoCSV()
    {
          string fileName = Application.persistentDataPath + "/AITtrial.csv";
          string trialDeets = "\n" + GlobalVars.xType + "," + pressed + "," + GlobalVars.xCorrect + "," + GlobalVars.xRT + "," + System.DateTime.Now;

        if (!File.Exists(fileName))
        {
            string trialHeader = "TrialType" + "," + "Pressed" + "," + "Correct" + "," + "RT" + "," + "DateTime";
            File.WriteAllText(fileName, trialHeader);
        }
        File.AppendAllText(fileName, trialDeets);
    }


    //public void EndBlock()
    //{
    //    ScoreKeeper.inTrial = false;


    //    if (LevelChanger.savingOn == true)
    //    {

    //        string fileName = Application.persistentDataPath + "/AITblock.csv";
    //        string trialDeets = "\n" + DataHandler.UID + "," + DataHandler.Age + "," + DataHandler.Sex + "," + DataHandler.BFOrderNumber + "," + DataHandler.dCDxApAvTotalPoints + "," + DataHandler.dCDxApAvCollects + "," + DataHandler.dCDxApAvCaptures + "," + System.DateTime.Now;

    //        if (!File.Exists(fileName))
    //        {
    //            string trialHeader = "UID" + "," + "Age" + "," + "Sex" + "," + "Order" + "," + "Points" + "," + "Collects" + "," + "Captures" + "," + "DateTime";
    //            File.WriteAllText(fileName, trialHeader);
    //        }
    //        File.AppendAllText(fileName, trialDeets);
    //    }
    //    SceneManager.LoadScene("IntervalMenu");
    //}


}



