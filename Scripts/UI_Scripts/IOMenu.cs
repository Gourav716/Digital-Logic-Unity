using UnityEngine;
using UnityEngine.EventSystems;

public class IOMenu : MonoBehaviour
{
    GameObject inputPanel;
    GameObject outputPanel;
    GameObject logicGatePanel;

    public GameObject currentObject;
    [SerializeField] CanvasGroup toolsCanvasGroup;

    private void Start()
    {
        inputPanel = transform.GetChild(0).gameObject;
        inputPanel.SetActive(false);

        outputPanel = transform.GetChild(1).gameObject;
        outputPanel.SetActive(false);

        logicGatePanel = transform.GetChild(2).gameObject;
        logicGatePanel.SetActive(false);

        toolsCanvasGroup.blocksRaycasts = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !GlobalData._IsWireDragging && !GlobalData._IsIOPrefabDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D;
            if (hit2D = Physics2D.Raycast(mousePosition, Vector2.zero))
            {
                if (hit2D.collider.CompareTag("Main Input"))
                {
                    inputPanel.transform.position = mousePosition;
                    inputPanel.SetActive(true);
                    toolsCanvasGroup.blocksRaycasts = false;

                    GlobalData._IsContextPanelCreated = true;
                    currentObject = hit2D.transform.parent.gameObject;
                }

                if (hit2D.collider.CompareTag("Main Output"))
                {
                    outputPanel.transform.position = mousePosition;
                    outputPanel.SetActive(true);
                    toolsCanvasGroup.blocksRaycasts = false;

                    GlobalData._IsContextPanelCreated = true;
                    currentObject = hit2D.transform.parent.gameObject;
                }

                if (hit2D.collider.CompareTag("Logic Gate"))
                {
                    logicGatePanel.transform.position = mousePosition;
                    logicGatePanel.SetActive(true);
                    toolsCanvasGroup.blocksRaycasts = false;

                    GlobalData._IsContextPanelCreated = true;
                    currentObject = hit2D.transform.gameObject;
                }
            }
        }

        if (GlobalData._IsContextPanelCreated)
        {
            if (!EventSystem.current.IsPointerOverGameObject() && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
            {
                DisableContextPanel();
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                DisableContextPanel();
            }
        }

        /*if (GlobalData._IsWireDragging)
        {
            toolsCanvasGroup.blocksRaycasts = false;
        }
        else
        {
            toolsCanvasGroup.blocksRaycasts = true;
        }*/
    }

    public void DisableContextPanel()
    {
        GlobalData._IsContextPanelCreated = false;
        inputPanel.SetActive(false);
        outputPanel.SetActive(false);
        logicGatePanel.SetActive(false);
        toolsCanvasGroup.blocksRaycasts = true;
    }
}
