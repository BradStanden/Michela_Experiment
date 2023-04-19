using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class EEGBaselineInstantiator : MonoBehaviour
{
    public GameObject startObs;
    public GameObject eoObs;
    public GameObject ecObs;
    public GameObject CE;
    public int index;
    public float timer;
    public float baselineDuration;
    public AudioSource endTone;

    public TextMeshProUGUI eoInstructions;
    public TextMeshProUGUI ecInstructions;

    void Awake()
    {
        baselineDuration = GlobalVars.baselineDuration;
        GlobalVars.currentCondition = "Baseline";
        startObs.SetActive(true);
        eoObs.SetActive(false);
        ecObs.SetActive(false);
        CE.SetActive(false);
        index = 0;
        timer = 0;
        eoInstructions.text = "We need to collect some baseline recordings of your brain. We will collect " + baselineDuration + " seconds of data with your eyes open then another " + baselineDuration + " seconds with your eyes closed. <br>First, we will collect your eyes open data.When you press start a fixation cross will appear in the middle of the screen.Please focus on this and try to remain still.You can blink as normal. ";
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (index == 1 && timer >= baselineDuration)
        {
            GlobalVars.triggerCode = 99;
            SaveIntoCSV();
            eyesClosedinstructions();
        }

        if (index == 3 && timer >= baselineDuration)
        {
            GlobalVars.triggerCode = 99;
            SaveIntoCSV();
            endTone.Play();
            timer = 0;
            StartCoroutine(UpdateBoolAfterDelay());
        }

    }

    public void eyesOpen()
    {
        startObs.SetActive(false);
        eoObs.SetActive(true);
        ecObs.SetActive(false);
        index = 1;
        timer = 0;
        GlobalVars.triggerCode = 1;
        SaveIntoCSV();
    }

    public void eyesClosedinstructions()
    {
        
        startObs.SetActive(false);
        eoObs.SetActive(false);
        ecObs.SetActive(true);
        index = 2;
        timer = 0;
    }
    public void eyesClosed()
    {
        GlobalVars.triggerCode = 2;
        SaveIntoCSV();
        endTone.Play();
        startObs.SetActive(false);
        eoObs.SetActive(false);
        ecObs.SetActive(false);
        CE.SetActive(true);
        // Disable the main light source
        RenderSettings.sun.enabled = false;

        // Set the ambient light color to black
        RenderSettings.ambientLight = Color.black;
        index = 3;
        timer = 0;
    }

    IEnumerator UpdateBoolAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        LevelContoller.next = true;
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
