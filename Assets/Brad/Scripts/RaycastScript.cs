using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastScript : MonoBehaviour
{
    public InputActionReference triggerAction;
    public float raycastDistance = 10f;

    public Color rayColorDefault = Color.green;
    public Color rayColorHit = Color.red;

    private LineRenderer lineRenderer;
    private GameObject currentHitObject;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        lineRenderer.enabled = true;
        lineRenderer.material.color = rayColorDefault;
    }

    private void OnEnable()
    {
        triggerAction.action.Enable();
        triggerAction.action.performed += CheckHit;
        triggerAction.action.canceled += ClearHit;
    }

    private void OnDisable()
    {
        triggerAction.action.Disable();
        triggerAction.action.performed -= CheckHit;
        triggerAction.action.canceled -= ClearHit;
    }

    private void CheckHit(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(lineRenderer.transform.position, lineRenderer.transform.forward, out hit, raycastDistance))
        {
            currentHitObject = hit.collider.gameObject;
            Debug.Log("Hit " + currentHitObject.name);
            lineRenderer.material.color = rayColorHit;
        }
        else
        {
            currentHitObject = null;
        }
    }

    private void ClearHit(InputAction.CallbackContext context)
    {
        currentHitObject = null;
        lineRenderer.material.color = rayColorDefault;
    }

    private void Update()
    {
        if (currentHitObject != null && triggerAction.action.ReadValue<float>() > 0)
        {
            lineRenderer.material.color = rayColorHit;
        }
        else
        {
            lineRenderer.material.color = rayColorDefault;
        }

        lineRenderer.SetPosition(0, lineRenderer.transform.position);
        lineRenderer.SetPosition(1, lineRenderer.transform.position + lineRenderer.transform.forward * raycastDistance);
    }
}
