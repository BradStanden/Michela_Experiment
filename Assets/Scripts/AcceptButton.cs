using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptButton : MonoBehaviour
{
    public GameObject xKeyboard;
    public void Accept()
    {

        xKeyboard.SetActive(false);
        if (GlobalVars.whatType == "UID")
        {
            GlobalVars.UID = textDisplay.xTextEntry;
        }
        if (GlobalVars.whatType == "Age")
        {
            GlobalVars.Age = textDisplay.xTextEntry;
        }
        if (GlobalVars.whatType == "Specify")
        {
            GlobalVars.Sex = textDisplay.xTextEntry;
        }
        textDisplay.xTextEntry = "";


    }
}
