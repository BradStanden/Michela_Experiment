using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCol : MonoBehaviour
{

    public int iCount;
    public Renderer sphere;

    private void Awake()
    {
        iCount = 0;
        sphere = GetComponent<Renderer>();

    }
    public void changer()
    {
        if (GlobalVars.inTrial == true)
        {
            iCount += 1;
            if (iCount > GlobalVars.condition)
            {
                iCount = 0;
            }

            if (GlobalVars.condition == 1)
            {
                if (iCount == 0)
                {
                    sphere.material.color = Color.grey;
                }
                else if (iCount == 1)
                {
                    sphere.material.color = Color.magenta;
                }
            }
            if (GlobalVars.condition == 2)
            {
                if (iCount == 0)
                {
                    sphere.material.color = Color.grey;
                }
                else if (iCount == 1)
                {
                    sphere.material.color = Color.magenta;
                }
                else if (iCount == 2)
                {
                    sphere.material.color = Color.blue;
                }
            }
            if (GlobalVars.condition == 3)
            {
                if (iCount == 0)
                {
                    sphere.material.color = Color.grey;
                }
                else if (iCount == 1)
                {
                    sphere.material.color = Color.magenta;
                }
                else if (iCount == 2)
                {
                    sphere.material.color = Color.blue;
                }
                else if (iCount == 3)
                {
                    sphere.material.color = Color.green;
                }
            }
        }


    }
}
