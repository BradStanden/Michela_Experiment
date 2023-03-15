using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NineShotInstantiator : MonoBehaviour
{
    public GameObject canvas;
    public AudioSource buzz;

    public float timer;
    public float RT;

    public TextMeshProUGUI displayTimer;
    public TextMeshProUGUI displayRT;

    public List<GameObject> boxes;

    public bool inTrial;

    void Awake()
    {
        timer = 0;
        GlobalVars.Target = "Box1";
        GlobalVars.TargetHitColor = Color.magenta;
        GlobalVars.NoHitColor = Color.blue;
        PauseTrial();
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
    }

    // Update is called once per frame
    void Update()
    {

        if (inTrial == true)
        {
            timer += Time.deltaTime;
        }
       
        displayTimer.text = timer.ToString();

    }

    public void tookShot()
    {
    if (GlobalVars.TargetHit == true && inTrial == true)
        {
            GlobalVars.Success = true;
            GlobalVars.selectedObject.GetComponent<Renderer>().material.color = GlobalVars.TargetHitColor;
            RT = timer;
            PauseTrial();
        }

        
    }

    void PauseTrial()
    {
        inTrial = false;
        displayRT.text = ("RT = " + RT);
        foreach (GameObject box in boxes)
        {

                Renderer renderer = box.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.grey;
                }
            
        }
        timer = 0;
    }
    public void ResetTrial()
    {

      

        GlobalVars.Target = "Box1";

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


        
        inTrial = true;

    }
}
