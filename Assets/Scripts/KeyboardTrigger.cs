using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardTrigger : MonoBehaviour
{
    public string KeyValue;
    void Start()
    {
        KeyValue = gameObject.GetComponent<TextMeshProUGUI>().text;
    }

    public void Clicked()
    {

    textDisplay.xTextEntry = textDisplay.xTextEntry + KeyValue;
      


    }

           
}
