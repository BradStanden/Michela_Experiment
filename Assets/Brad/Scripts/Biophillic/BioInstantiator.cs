using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BioInstantiator : MonoBehaviour
{

    public Material Stairs1;
    public Material Stairs2;
    public Material Stairs3;
    public Material Stairs4;

    public int level;

    public TextMeshProUGUI roomNo;
    public GameObject instructions;




    void Start()
    {
        level = 0;
 

    }

    public void Update()
    {
        roomNo.text = ("Room #: " + level);
    }


    public void increaseB()
    {
        instructions.SetActive(false);
        level += 1;
        if (level > 4)
        {
            level = 4;
        }

        if (level == 1)
        {
            RenderSettings.skybox = Stairs1;
        }
        else if (level == 2)
        {
            RenderSettings.skybox = Stairs2;
        }
        else if (level == 3)
        {
            RenderSettings.skybox = Stairs3;
        }
        else if (level == 4)
        {
            RenderSettings.skybox = Stairs4;
        }
    }

    public void decreaseB()
    {
        instructions.SetActive(false);
        level -= 1;
        if (level < 1)
        {
            level = 1;
        }

        if (level == 1)
        {
            RenderSettings.skybox = Stairs1;
        }
        else if (level == 2)
        {
            RenderSettings.skybox = Stairs2;
        }
        else if (level == 3)
        {
            RenderSettings.skybox = Stairs3;
        }
        else if (level == 4)
        {
            RenderSettings.skybox = Stairs4;
        }
    }
}
