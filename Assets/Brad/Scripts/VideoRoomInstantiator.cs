using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoRoomInstantiator : MonoBehaviour
{
    public float timer;
    public VideoClip Neutral1;
    public VideoClip Neutral2;
    public VideoClip Negative1;
    public VideoClip Negative2;
    public VideoClip Positive1;
    public VideoClip Positive2;

    public VideoPlayer videoPlayer;

    public int counter;

    void Awake()
    {
        timer = 0;
       

        ///sorts out the condition
        counter = Random.Range(0, GlobalVars.conditionList.Count);
        GlobalVars.currentCondition = GlobalVars.conditionList[counter];
        GlobalVars.conditionList.RemoveAt(counter);

        if (GlobalVars.currentCondition == "Neutral1")
        {
            videoPlayer.clip = Neutral1;
        }
        if (GlobalVars.currentCondition == "Neutral2")
        {
            videoPlayer.clip = Neutral2;
        }
        if (GlobalVars.currentCondition == "Negative1")
        {
            videoPlayer.clip = Negative1;
        }
        if (GlobalVars.currentCondition == "Negative2")
        {
            videoPlayer.clip = Negative2;
        }
        if (GlobalVars.currentCondition == "Positive1")
        {
            videoPlayer.clip = Positive1;
        }
        if (GlobalVars.currentCondition == "Positive2")
        {
            videoPlayer.clip = Positive2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            LevelContoller.next = true;
        }
        
    }
}
