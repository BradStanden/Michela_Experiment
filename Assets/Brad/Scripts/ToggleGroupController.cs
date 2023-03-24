using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupController : MonoBehaviour
{
    ToggleGroup toggleGroup;

    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    public void valueChange()
    {
        Toggle toggle = toggleGroup.GetFirstActiveToggle();

        if (gameObject.name == "Q1")
        {
            if (PANASinstantiator.stage == 1)
            {
                GlobalVars.relaxed = toggle.name;
            }
            if (PANASinstantiator.stage == 2)
            {
                GlobalVars.angry = toggle.name;
            }
        }

        if (gameObject.name == "Q2")
        {
            if (PANASinstantiator.stage == 1)
            {
                GlobalVars.sad = toggle.name;
            }
            if (PANASinstantiator.stage == 2)
            {
                GlobalVars.joyful = toggle.name;
            }
        }

        if (gameObject.name == "Q3")
        {
            if (PANASinstantiator.stage == 1)
            {
                GlobalVars.calm = toggle.name;
            }
            if (PANASinstantiator.stage == 2)
            {
                GlobalVars.hostile = toggle.name;
            }
        }

        if (gameObject.name == "Q4")
        {
            if (PANASinstantiator.stage == 1)
            {
                GlobalVars.afraid = toggle.name;
            }
            if (PANASinstantiator.stage == 2)
            {
                GlobalVars.scared = toggle.name;
            }
        }

        if (gameObject.name == "Q5")
        {
            if (PANASinstantiator.stage == 1)
            {
                GlobalVars.happy = toggle.name;
            }
            if (PANASinstantiator.stage == 2)
            {
                GlobalVars.downhearted = toggle.name;
            }
        }

    }
}
