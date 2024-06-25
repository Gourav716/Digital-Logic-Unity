using UnityEngine;

public class IOPortMove : MonoBehaviour
{
    Vector3 offsetPosition;

    public bool isIODragging;

    private void Start()
    {
        isIODragging = false;
    }

    private void OnMouseUp()
    {
        GlobalData._IsIOPrefabDragging = false;
        isIODragging = false;
    }

    private void OnMouseDown()
    {
        if (!GlobalData._IsWireDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offsetPosition = mousePosition - transform.parent.position;

            isIODragging = true;
            GlobalData._CurrentIOMoveComponent = gameObject.GetComponent<IOPortMove>();
        }
    }

    private void OnMouseDrag()
    {
        if (!GlobalData._IsContextPanelCreated && !GlobalData._IsWireDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition -= offsetPosition;
            transform.parent.position = mousePosition;
        }
    }

    private void Update()
    {
        if (GlobalData._IsIOPrefabDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            GlobalData._CurrentIOPrefab.transform.position = mousePosition;

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(GlobalData._CurrentIOPrefab);
                GlobalData._IsIOPrefabDragging = false;
            }
        }
    }
}
