using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class DemographicsInstantiator : MonoBehaviour
{
    public TMP_InputField UIDtext;
    public TMP_InputField Agetext;
    public TMP_InputField Sextext;


    public TextMeshProUGUI error;

    public GameObject Sex;
    public GameObject UID;
    public GameObject Age;
    public GameObject Keyboard;


    public void Awake()
    {
        Age.SetActive(true);
        UID.SetActive(true);
        Keyboard.SetActive(false);
        GlobalVars.index = 0;
      

    }
    public void Update()
    {
        UIDtext.text = GlobalVars.UID;
        Agetext.text = GlobalVars.Age;
        Sextext.text = GlobalVars.Sex;


    }
    public void submitDemographics()
    {
        if (GlobalVars.UID == null || GlobalVars.Age == null || GlobalVars.Sex == null || GlobalVars.Randomization == null)
        {
            if (GlobalVars.UID == null)
            {
                error.text = "Please enter a UID";
            }
            else if (GlobalVars.Age == null)
            {
                error.text = "Please enter an age";
            }
            else if (GlobalVars.Sex == null)
            {
                error.text = "Please select an option for sex";
            }
            else if (GlobalVars.Randomization == null)
            {
                error.text = "Please enter a condition";
            }
        }
        else 
        {
            LevelContoller.next = true;
        }


    }

    public void UIDentry()
    {
        Keyboard.SetActive(true);
        GlobalVars.whatType = "UID";

    }

    public void Ageentry()
    {
        Keyboard.SetActive(true);
        GlobalVars.whatType = "Age";

    }
    public void Male()
    {
        GlobalVars.Sex = "Male";

    }
    public void Cond1()
    {
        GlobalVars.Randomization = "1";
        GlobalVars.conditionList = new List<string> { "Fear", "Sadness", "Neutral", "Excite", "Relax" };

    }
    public void Cond2()
    {
        GlobalVars.Randomization = "2";
        GlobalVars.conditionList = new List<string> { "Excite", "Relax", "Neutral", "Fear", "Sadness" };
    }

    public void Female()
    {
        GlobalVars.Sex = "Female";

    }
    public void Specify()
    {
        GlobalVars.Sex = "Other";
        Sex.SetActive(true);

    }
    public void specifyEntry()
    {
        Keyboard.SetActive(true);
        GlobalVars.whatType = "Specify";

    }


}
