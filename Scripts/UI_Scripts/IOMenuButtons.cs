using UnityEngine;
using UnityEngine.UI;

public class IOMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject inputPortPanel;
    [SerializeField] GameObject outputPortPanel;

    Button inputPortButton;
    Button outputPortButton;

    private void Awake()
    {
        inputPortPanel.SetActive(false);
        outputPortPanel.SetActive(false);

        inputPortButton = transform.GetChild(0).GetComponent<Button>();
        outputPortButton = transform.GetChild(1).GetComponent<Button>();
    }

    private void Start()
    {
        inputPortButton.onClick.AddListener(InputButton);
        outputPortButton.onClick.AddListener(OutputButton);
    }

    void InputButton()
    {
        GlobalData._ToolsUIObjects.Push(inputPortPanel);
        inputPortPanel.SetActive(true);
        outputPortPanel.SetActive(false);
    }

    void OutputButton()
    {
        GlobalData._ToolsUIObjects.Push(outputPortPanel);
        outputPortPanel.SetActive(true);
        inputPortPanel.SetActive(false);
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !GlobalData._IsToolsPanelCreated)
        {
            inputPortPanel.SetActive(false);
            outputPortPanel.SetActive(false);
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inputPortPanel.SetActive(false);
            outputPortPanel.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
