using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class PANASinstantiator : MonoBehaviour
{
    public TextMeshProUGUI Q1;
    public TextMeshProUGUI Q2;
    public TextMeshProUGUI Q3;
    public TextMeshProUGUI Q4;
    public TextMeshProUGUI Q5;

    public TextMeshProUGUI error;

    public ToggleGroup T1;
    public ToggleGroup T2;
    public ToggleGroup T3;
    public ToggleGroup T4;
    public ToggleGroup T5;




    public GameObject Part1;
    public GameObject Part2;
    public static int stage;

    public bool errorOccured;



    private void Start()
    {
  
        GlobalVars.relaxed = "0";
        GlobalVars.sad = "0";
        GlobalVars.calm = "0";
        GlobalVars.afraid = "0";
        GlobalVars.happy = "0";
        GlobalVars.angry = "0";
        GlobalVars.joyful = "0";
        GlobalVars.hostile = "0";
        GlobalVars.scared = "0";
        GlobalVars.downhearted = "0";
        Part1.SetActive(true);
        Part2.SetActive(false);
        error.text = "";
        stage = 1;
        Q1.text = "Relaxed";
        Q2.text = "Sad";
        Q3.text = "Calm";
        Q4.text = "Afraid";
        Q5.text = "Happy";



        toggleOff();


    }

    public void NextStage()
    {
  
        if (GlobalVars.relaxed == "0"|| GlobalVars.sad == "0" || GlobalVars.calm == "0" || GlobalVars.afraid == "0" || GlobalVars.happy == "0")
        {
            error.text = "Please select an option for every question";
        }
        else if (GlobalVars.relaxed == "NA" || GlobalVars.sad == "NA" || GlobalVars.calm == "NA" || GlobalVars.afraid == "NA" || GlobalVars.happy == "NA")
        {
            error.text = "Please select an option for every question";

        }
        else
        {
        Part1.SetActive(false);
        Part2.SetActive(true);
        error.text = "";
        stage = 2;
        Q1.text = "Angry";
        Q2.text = "Joyful";
        Q3.text = "Hostile";
        Q4.text = "Scared";
        Q5.text = "Down-hearted";
        toggleOff();
        }




    }

    public void toggleOff()
    {
        Toggle[] toggles = FindObjectsOfType<Toggle>();

        foreach (Toggle toggle in toggles)
        {
            if (toggle.name == "NA")
            {
                toggle.isOn = true;
            }
            
        }


    }


    public void NextLevel()
    {
        if (GlobalVars.angry == "0" || GlobalVars.joyful == "0" || GlobalVars.hostile == "0" || GlobalVars.scared == "0" || GlobalVars.downhearted == "0")
        {
            error.text = "Please select an option for every question";
        }
        else if (GlobalVars.angry == "NA" || GlobalVars.joyful == "NA" || GlobalVars.hostile == "NA" || GlobalVars.scared == "NA" || GlobalVars.downhearted == "NA")
        {
            error.text = "Please select an option for every question";

        }
        else
        {
            string fileName = Application.persistentDataPath + "/PANAS.csv";
            string trialDeets = "\n" + GlobalVars.UID + "," + GlobalVars.Age + "," + GlobalVars.Sex + "," + GlobalVars.currentBlock + "," + GlobalVars.currentLevel + "," + GlobalVars.currentCondition + "," + GlobalVars.relaxed + "," + GlobalVars.sad + "," + GlobalVars.calm + "," + GlobalVars.afraid + "," + GlobalVars.happy + "," + GlobalVars.angry + "," + GlobalVars.joyful + "," + GlobalVars.hostile + "," + GlobalVars.scared + "," + GlobalVars.downhearted + "," + System.DateTime.Now;
            if (!File.Exists(fileName))
            {
                string trialHeader = "UID" + "," + "Age" + "," + "Sex" + "," + "Block" + "," + "Level" + "," + "Condition" + "," + "Relaxed" + "," + "Sad" + "," + "Calm" + "," + "Afraid" + "," + "Happy" + "," + "Angry" + "," + "Joyful" + "," + "Hostile" + "," + "Scared" + "," + "Downhearted" + "," + "DateTime";
                File.WriteAllText(fileName, trialHeader);
            }
            File.AppendAllText(fileName, trialDeets);
            LevelContoller.next = true;
        }
    }

}


