using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textDisplay : MonoBehaviour
{
    public static string xTextEntry;
    public TextMeshProUGUI xEntry;
    void Start()
    {
        xTextEntry = "";
    }

    void Update()
    {
        xEntry.text = xTextEntry;
    }
}
