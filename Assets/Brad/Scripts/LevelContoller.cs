using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(GlobalVars.currentLevel);

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
