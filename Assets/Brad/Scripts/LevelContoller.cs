using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelContoller : MonoBehaviour
{



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
