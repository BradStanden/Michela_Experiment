using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoRoomInstantiator : MonoBehaviour
{
    public float timer;
    public VideoClip Neutral;
    public VideoClip Sadness;
    public VideoClip Fear;
    public VideoClip Relax;
    public VideoClip Excite;

    public VideoPlayer videoPlayer;

    public GameObject player;

    public int counter;
    public bool once;

    void Awake()
    {
        timer = 0;
        once = false;

        ///sorts out the condition
        counter = Random.Range(0, GlobalVars.conditionList.Count);
        GlobalVars.currentCondition = GlobalVars.conditionList[counter];
        GlobalVars.conditionList.RemoveAt(counter);

        if (GlobalVars.currentCondition == "Neutral")
        {
            videoPlayer.clip = Neutral;
            player.transform.Rotate(0f, 180f, 0.0f, Space.World);
        }

        if (GlobalVars.currentCondition == "Sadness")//Sadness
        {
            videoPlayer.clip = Sadness;
           
        }
        if (GlobalVars.currentCondition == "Fear")//Fear
        {
            videoPlayer.clip = Fear;
        }
        if (GlobalVars.currentCondition == "Relax")//Relax
        {
            videoPlayer.clip = Relax;
            player.transform.Rotate(0f, -45f, 0.0f, Space.World);
        }
        if (GlobalVars.currentCondition == "Excite")//Excitement
        {
            videoPlayer.clip = Excite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= 20f && once == false)
        {
            once = true;
            LevelContoller.next = true;
        }
        
    }
}
