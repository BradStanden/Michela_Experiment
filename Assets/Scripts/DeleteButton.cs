using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeleteButton : MonoBehaviour
{



    public void Delete()
    {

        textDisplay.xTextEntry = textDisplay.xTextEntry.Substring(0, textDisplay.xTextEntry.Length - 1);
        Debug.Log(textDisplay.xTextEntry);


    }


}


