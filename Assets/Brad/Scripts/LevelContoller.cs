using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelContoller : MonoBehaviour
{
    public static bool next;

    public void Update()
    {
        if (next == true)
        {
            Next();
        }
    }
    public void Next()
    {
        next = false;
        GlobalVars.index += 1;
        GlobalVars.currentBlock = GlobalVars.setupData[GlobalVars.index, 1];
        GlobalVars.currentLevel = GlobalVars.setupData[GlobalVars.index, 0];
        GlobalVars.currentVersion = GlobalVars.setupData[GlobalVars.index, 2];
        if (GlobalVars.currentLevel == "SAM")
        {
            GlobalVars.triggerCode = 3;
        }
        if (GlobalVars.currentLevel == "PANAS")
        {
            GlobalVars.triggerCode = 4;
        }
        if (GlobalVars.currentLevel == "AIT")
        {
            GlobalVars.triggerCode = 5;
        }
        if (GlobalVars.currentLevel == "EEGBaseline")
        {
            GlobalVars.triggerCode = 6;
        }
        if (GlobalVars.currentLevel == "VideoRoom")
        {
            GlobalVars.triggerCode = 7;
        }
        trigger();
        SceneManager.LoadScene(GlobalVars.currentLevel);

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
    public void NineShot()
    {
        SceneManager.LoadScene("NineShot");
    }
    public void Reaction()
    {
        SceneManager.LoadScene("Reaction");
 
    }
    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void Biophillic()
    {

        SceneManager.LoadScene("Biophillic");
    }

    public void AIT()
    {

        SceneManager.LoadScene("AIT");
    }

    public void SAM()
    {

        SceneManager.LoadScene("SAM");
    }

    public void VideoRoom()
    {

        SceneManager.LoadScene("VideoRoom");
    }

    
}
