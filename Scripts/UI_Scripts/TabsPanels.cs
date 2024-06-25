using UnityEngine;
using UnityEngine.UI;

public class TabsPanels : MonoBehaviour
{
    [SerializeField] GameObject IOPortsPanel;
    [SerializeField] GameObject GatesPanel;

    Button inputOutputButton;
    Button gateButton;

    private void Awake()
    {
        IOPortsPanel.SetActive(false);
        GatesPanel.SetActive(false);

        inputOutputButton = transform.GetChild(0).GetComponent<Button>();
        gateButton = transform.GetChild(1).GetComponent<Button>();
    }

    private void Start()
    {
        inputOutputButton.onClick.AddListener(InputOutputButton);
        gateButton.onClick.AddListener(GateButton);
    }

    void InputOutputButton()
    {
        GlobalData.DeactivateComponentUI();

        IOPortsPanel.SetActive(true);
        GlobalData._ToolsUIObjects.Push(IOPortsPanel);
        GlobalData._IsToolsPanelCreated = true;
    }

    void GateButton()
    {
        GlobalData.DeactivateComponentUI();

        GatesPanel.SetActive(true);
        GlobalData._ToolsUIObjects.Push(GatesPanel);
        GlobalData._IsToolsPanelCreated = true;
    }

    private void Update()
    {
        if (GlobalData._IsWireDragging && (inputOutputButton.enabled || gateButton.enabled))
        {
            inputOutputButton.enabled = false;
            gateButton.enabled = false;
        }

        if (!GlobalData._IsWireDragging && (!inputOutputButton.enabled || !gateButton.enabled))
        {
            inputOutputButton.enabled = true;
            gateButton.enabled = true;
        }
    }
}
