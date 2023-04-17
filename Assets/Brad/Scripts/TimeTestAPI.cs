using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TimeTestAPI : MonoBehaviour
{

    public DateTime systemTime;

    [Serializable]
    private class DateTimeObject
    {
        public string datetime;
    }
    void Start()
    {

        StartCoroutine(GetInternetTime());

    
    }

    public class TimingStuff
    {
        public string abbreviation;
        public string client_ip;
        public string datetime;
    }
    public IEnumerator GetInternetTime()
    {
        UnityWebRequest webR = UnityWebRequest.Get("http://worldtimeapi.org/api/ip");
        webR.timeout = 1;
        yield return webR.SendWebRequest();
 

        if (webR.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(webR.error);
        }
        else
        {
            systemTime = System.DateTime.Now;
            string text = webR.downloadHandler.text;

            DateTimeObject dateTimeObject = JsonUtility.FromJson<DateTimeObject>(text);

            string dateTimeString = dateTimeObject.datetime;

            DateTime dateTime = DateTime.ParseExact(dateTimeString, "yyyy-MM-ddTHH:mm:ss.ffffffK", null);
            TimeSpan offset = systemTime - dateTime; 

            string fileName = Application.persistentDataPath + "/TimeOffsets.csv";
            string trialDeets = "\n" + GlobalVars.UID + "," + GlobalVars.Age + "," + GlobalVars.Sex + "," + systemTime.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK") + "," + dateTime.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK") + "," + offset.ToString();
            if (!File.Exists(fileName))
            {
                string trialHeader = "UID" + "," + "Age" + "," + "Sex" + "," + "DeviceTime" + "," + "NetTime" + "," + "Offset";
                File.WriteAllText(fileName, trialHeader);
            }
            File.AppendAllText(fileName, trialDeets);
       
        }

    }


}
