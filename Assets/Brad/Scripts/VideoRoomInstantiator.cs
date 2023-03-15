using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoRoomInstantiator : MonoBehaviour
{
    public float timer;
    void Awake()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            SceneManager.LoadScene("AIT");
        }
        
    }
}
