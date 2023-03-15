using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RTIntantiator : MonoBehaviour
{
    public GameObject canvas;
    public AudioSource buzz;

    public GameObject BoxParent;

    public float timer;
    public float randNo;
    public float RT;

    public TextMeshProUGUI displayTimer;
    public TextMeshProUGUI displayRT;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI instructionsText;

    public List<GameObject> boxes;
    public List<int> trialNo;

    public int totalTrials;
    public int rand;
    public int trialsLeft;
    public bool inTrial;
    public GameObject instructions;
    public GameObject levelButtons;

    public string targetID;


    void Awake()
    {
        timer = 0;
        trialNo = new List<int> {1, 2, 2, 3, 4, 4, 5, 5, 6, 6, 7, 8, 8, 9 };
        totalTrials = trialNo.Count;
        GlobalVars.TargetHitColor = Color.magenta;
        GlobalVars.NoHitColor = Color.blue;
        GlobalVars.totalScore = 0;
        instructions.SetActive(true);
        levelButtons.SetActive(false);


    }

    void Start()
    {
        // Find all game objects in the scene with the tag "box".
        GameObject[] boxObjects = GameObject.FindGameObjectsWithTag("box");

        // Add each box object to the list of boxes.
        foreach (GameObject box in boxObjects)
        {
            boxes.Add(box);
        }

        PauseTrial();
    }

    // Update is called once per frame
    void Update()
    {

        if (inTrial == true)
        {
            timer += Time.deltaTime;
        }

        trialsLeft = trialNo.Count;
        displayTimer.text = ("Trials Remaining: " + trialsLeft);

        targetID = GlobalVars.Target;
 

    }

    public void tookShot()
    {
        if (GlobalVars.TargetHit == true && inTrial == true && (GlobalVars.Target == GlobalVars.selectedObject.name))
        {
            GlobalVars.Success = true;
            RT = timer;
            PauseTrial();
        }


    }

    public void PauseTrial()
    {
       
        inTrial = false;
        if (RT> GlobalVars.highScore)
        {
            GlobalVars.highScore = RT;
        }
        else if (RT> GlobalVars.secondHighScore)
        {
            GlobalVars.secondHighScore = RT;
        }
        GlobalVars.totalScore += RT;
        displayRT.text = ("RT = " + RT);
        foreach (GameObject box in boxes)
        {

            Renderer renderer = box.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.grey;
            }

        }
        if (trialNo.Count < 1)
        {
            buttonText.text = "Get Score";
        }
            BoxParent.SetActive(false);
        timer = 0;
    }
    public void ResetTrial()
    {
        instructions.SetActive(false);
        buttonText.text = "Next Trial";
        ///If statement for Target Selection
        if (trialNo.Count > 1)
        {
            BoxParent.SetActive(true);
            rand = Random.Range(0, (trialNo.Count - 1));
            //rand = Random.Range(0, (trialNo.Count - 1));
            GlobalVars.Target = ("Box" + trialNo[rand].ToString());
            randNo = Random.Range(2, 3);
            StartCoroutine(pauseRand());




        }
        else
        {
            instructions.SetActive(true);
            levelButtons.SetActive(true);
            float finalRT = ((GlobalVars.totalScore - (GlobalVars.highScore + GlobalVars.secondHighScore)));
            instructionsText.text = ("Total Time Taken (excluding 2 slowest): " + finalRT);

        }
    }

    public void SpawnTrial()
    {
        foreach (GameObject box in boxes)
        {
            Renderer renderer = box.GetComponent<Renderer>();

            if (box.name != GlobalVars.Target)
            {

                if (renderer != null)
                {
                    renderer.material.color = GlobalVars.NoHitColor;
                }
            }
            else
            {
                if (renderer != null)
                {
                    renderer.material.color = GlobalVars.TargetHitColor;
                }
            }
        }


        trialNo.RemoveAt(rand);
        inTrial = true;


    }

        private IEnumerator pauseRand()
    {
        

        yield return new WaitForSeconds(randNo);
        SpawnTrial();
      
    }
}
