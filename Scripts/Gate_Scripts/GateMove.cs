using UnityEngine;

public class GateMove : MonoBehaviour
{
    Vector3 offsetPosition;

    public bool isGateDragging;

    private void Start()
    {
        isGateDragging = false;
    }

    private void OnMouseUp()
    {
        isGateDragging = false;
        GlobalData._IsLogicGateDragging = false;
    }

    private void OnMouseDown()
    {
        if (!GlobalData._IsWireDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offsetPosition = mousePosition - transform.position;

            isGateDragging = true;
            GlobalData._CurrentGateMoveComponent = gameObject.GetComponent<GateMove>();
        }
    }

    private void OnMouseDrag()
    {
        if (!GlobalData._IsToolsPanelCreated && !GlobalData._IsWireDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition -= offsetPosition;
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
    }

    private void Update()
    {
        if (GlobalData._IsLogicGateDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            GlobalData._CurrentGatePrefab.transform.position = mousePosition;

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(GlobalData._CurrentGatePrefab);
                GlobalData._IsLogicGateDragging = false;
            }
        }
    }
}
