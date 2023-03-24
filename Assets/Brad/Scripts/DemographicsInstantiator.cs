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
        LevelContoller.next = true;

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
