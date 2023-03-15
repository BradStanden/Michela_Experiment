using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;


public class Targeter : MonoBehaviour
{
    private XRRayInteractor rayInteractor;






    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();

    }

    void Update()
    {


        ////Raycast stuff
        RaycastHit hit;
        if (rayInteractor.TryGetCurrent3DRaycastHit(out hit))
        {
            if (hit.collider.gameObject.name.Equals(GlobalVars.Target))
            {
                GlobalVars.TargetHit = true;
                GlobalVars.selectedObject = hit.collider.gameObject;

            }
            GlobalVars.selectedObject = hit.collider.gameObject;

        }
        else
        {
            GlobalVars.TargetHit = false;
            GlobalVars.selectedObject = null;
        }

    }
}
