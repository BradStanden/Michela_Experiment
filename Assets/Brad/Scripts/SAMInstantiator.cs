using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class SAMInstantiator : MonoBehaviour
{
    public GameObject arousalObj;
    public GameObject valenceObj;
    public string Type;
    public TextMeshProUGUI error;


    private void Awake()
    {
        GlobalVars.Score = "0";
        arousalObj.SetActive(true);
        valenceObj.SetActive(false);
        Type = "Arousal";
        
    }

    public void Valence()
    {
        if (GlobalVars.Score != "0")
        {
            SaveIntoCSV();
            arousalObj.SetActive(false);
            valenceObj.SetActive(true);
            GlobalVars.Score = "0";
            Type = "Valence";
        }
        else
        {
            error.text = "please select an image";
        }

    }

    public void ContinueExperiment()
    {
        if (GlobalVars.Score != "0")
        {
            SaveIntoCSV();
            GlobalVars.Score = "0";
            LevelContoller.next = true;
        }
        else
        {
            error.text = "please select an image";
        }

    }

    public void SaveIntoCSV()
    {
        string fileName = Application.persistentDataPath + "/SAM.csv";
        string trialDeets = "\n" + GlobalVars.UID + "," + GlobalVars.Age + "," + GlobalVars.Sex + "," + GlobalVars.currentBlock + "," + GlobalVars.currentLevel + "," + GlobalVars.currentVersion + "," + GlobalVars.currentCondition + "," + Type + "," + GlobalVars.Score;
        if (!File.Exists(fileName))
        {
            string trialHeader = "UID" + "," + "Age" + "," + "Sex" + "," + "Block" + "," + "Level" + "," + "Version" + "," + "Condition" + "," + "Variable" + "," + "Score";
            File.WriteAllText(fileName, trialHeader);
        }
        File.AppendAllText(fileName, trialDeets);
    }
}
