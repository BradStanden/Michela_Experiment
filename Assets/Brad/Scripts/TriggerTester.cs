using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;

public class TriggerTester : MonoBehaviour
{
    public float timer;
    public float pressed;

    public TextMeshProUGUI display;
    public TextMeshProUGUI pdisplay;


    public void sendTime()
    {
        
        pdisplay.text = System.DateTime.Now.ToString("HH:mm:ss:fffff");
        SaveIntoCSV();
    }

    public void SaveIntoCSV()
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
