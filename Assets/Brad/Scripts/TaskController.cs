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
    public List<float> DurationList;
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
        //GlobalVars.xTrials = 16;
        rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        //tempList = new List<int> { 0 };

        //Added spare digit in both lists
        TrialList = new List<int> {99, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
        DurationList = new List<float> {99, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 0.9f, 0.9f, 0.9f, 0.9f, 0.9f, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 0.9f, 0.9f, 0.9f, 0.9f, 0.9f, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 0.9f, 0.9f, 0.9f, 0.9f, 0.9f, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 0.9f, 0.9f, 0.9f, 0.9f, 0.9f};
        finish = false;


        ///This was for outreach game to make short
        //if (GlobalVars.xTrials == 16)
        //{
        //    tempList.AddRange(TrialList);
        //    TrialList = tempList;

        //}

        //if (GlobalVars.xTrials == 32)
        //{
        //    tempList.AddRange(TrialList);
        //    tempList.AddRange(TrialList);
        //    TrialList = tempList;
        //}

        //if (GlobalVars.xTrials == 48)
        //{
        //    tempList.AddRange(TrialList);
        //    tempList.AddRange(TrialList);
        //    tempList.AddRange(TrialList);
        //    TrialList = tempList;
        //}
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
            GlobalVars.trialDuration = DurationList[counter]; 
            if (timer >= DurationList[counter])
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
            if (timer >= 1.5f)
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
                SaveIntoCSV();
                TrialSelect();
            }


            if (rightController.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                pressed = true;
                GlobalVars.triggerCode = 25;
                trigger();
                GlobalVars.xRT = timer;

                if (doPress == true)
                {
                    GlobalVars.xCorrect = true;


                }
                else 
                {                     
                    GlobalVars.xCorrect = false; 

                
                }
                SaveIntoCSV();
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
        GlobalVars.triggerCode = 98;
        trigger();
        TrialList.RemoveAt(counter);
        DurationList.RemoveAt(counter);

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
            GlobalVars.triggerCode = 21;
            
        }
        if (GlobalVars.xType == 1)//ConNoGo
        {
            curSkybox = noGoHand;
            curColor = noGoCol;
            doPress = false;
            GlobalVars.triggerCode = 22;
        }
        if (GlobalVars.xType == 2)//InconGo
        {
            curSkybox = noGoHand;
            curColor = goCol;
            doPress = true;
            GlobalVars.triggerCode = 23;
        }
        if (GlobalVars.xType == 3)//InconNoGo
        {
            curSkybox = goHand;
            curColor = noGoCol;
            doPress = false;
            GlobalVars.triggerCode = 24;
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

    //void primerDisplay()
    //{
    //    timer = 0;
    //    ballRend.material.color = Color.grey;
    //    fixi.SetActive(false);
    //    ball.SetActive(true);
    //    state = 3;
    //    RenderSettings.skybox = neutral;
    //}

    void TrialDisplay()
    {
        trigger();
        fixi.SetActive(false);
        ball.SetActive(true);
        timer = 0;
        state = 4;
        RenderSettings.skybox = curSkybox;
        ballRend.material.color = curColor;

        

    }

    public void EndExperiment()
    {
        GlobalVars.triggerCode = 99;
        trigger();
        LevelContoller.next = true;


    }



    void SaveIntoCSV()
    {
          string fileName = Application.persistentDataPath + "/AITtrial.csv";
          string trialDeets = "\n" + GlobalVars.UID + "," + GlobalVars.Age + "," + GlobalVars.Sex + "," + GlobalVars.xType + "," + GlobalVars.trialDuration + "," + pressed + "," + GlobalVars.xCorrect + "," + GlobalVars.xRT + "," + System.DateTime.Now;

        if (!File.Exists(fileName))
        {
            string trialHeader = "UID" + "," + "Age" + "," + "Sex" + "," + "TrialType" + "," + "Duration" + "," + "Pressed" + "," + "Correct" + "," + "RT" + "," + "DateTime";
            File.WriteAllText(fileName, trialHeader);
        }
        File.AppendAllText(fileName, trialDeets);
    }

    public void trigger()
    {
        string fileName = Application.persistentDataPath + "/Events/" + GlobalVars.UID + ".csv";
        string trialDeets = "\n" + GlobalVars.triggerCode + "," + System.DateTime.Now.ToString("HH:mm:ss:fffff") + "," + System.DateTime.Now.ToString("dd:MM:yyyy") + "," + GlobalVars.currentBlock + "," + GlobalVars.currentLevel + "," + GlobalVars.currentCondition;
        if (!File.Exists(fileName))
        {
            string trialHeader = "TriggerValue" + "," + "SaveTime" + "," + "SaveDate" + "," + "Block" + "," + "Level" + "," + "Condition";
            File.WriteAllText(fileName, trialHeader);
        }
        File.AppendAllText(fileName, trialDeets);
    }




}



