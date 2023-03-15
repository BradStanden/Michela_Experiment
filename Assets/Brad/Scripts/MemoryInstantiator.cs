using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MemoryIntantiator : MonoBehaviour
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
    public List<int> condNo;
    public List<int> randList;

    public int totalTrials;
    public int rand;
    public int trialsLeft;
    public bool inTrial;
    public GameObject instructions;
    public GameObject levelButtons;

    public string targetID;

    public int zCount;


    void Awake()
    {
        timer = 0;
        trialNo = new List<int> { 1, 2, 3, 4,  5, 6, 7, 8, 9 };
        condNo = new List<int> { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
        randList = new List<int> {};
        totalTrials = trialNo.Count;

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


    }

    public void Submit()
    {

            PauseTrial();
       

    }



    public void PauseTrial()
    {

        GlobalVars.inTrial = false;


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
            SpawnTrial();
  

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
        randList = new List<int> { };
        rand = Random.Range(0, (trialNo.Count - 1));
        GlobalVars.condition = condNo[rand];
        while (randList.Count < trialNo[rand])
        {
            int i = Random.Range(0, 9);
            randList.Add(i);
        }
        int pCount = 0;
        int bCount = 0;
        int gCount = 0;


        if (GlobalVars.condition == 1)
        {
            zCount = 0;

            while (pCount < trialNo[rand])
            {
               
                string zName = ("box" + trialNo[randList[zCount]]);
                
                
            }
        }

        foreach (GameObject box in boxes)
        {
            Renderer renderer = box.GetComponent<Renderer>();


            rand = Random.Range(0, (trialNo.Count - 1));
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

        StartCoroutine(pauseRand());



    }

    public void AnswerTrial()
    {
        GlobalVars.inTrial = false;

        foreach (GameObject box in boxes)
        {

            Renderer renderer = box.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.grey;
            }

        }



    }

    private IEnumerator pauseRand()
    {


        yield return new WaitForSeconds(8);
        AnswerTrial();

    }
}
