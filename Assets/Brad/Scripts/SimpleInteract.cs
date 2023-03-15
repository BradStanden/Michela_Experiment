using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteract : MonoBehaviour
{
    public AudioSource buzz;
   void selectionMade()
    {
        buzz.Play();
    }
}
