using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreButton : MonoBehaviour
{


 public void Pressed()
    {
        GlobalVars.Score = gameObject.name;
    }
}
