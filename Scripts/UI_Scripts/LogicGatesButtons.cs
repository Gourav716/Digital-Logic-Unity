using UnityEngine;
using UnityEngine.UI;

public class LogicGatesButtons : MonoBehaviour
{
    [SerializeField] GameObject NOTGatePrefab;
    [SerializeField] GameObject ANDGatePrefab;
    [SerializeField] GameObject ORGatePrefab;
    [SerializeField] GameObject NANDGatePrefab;
    [SerializeField] GameObject NORGatePrefab;
    [SerializeField] GameObject XORGatePrefab;
    [SerializeField] GameObject XNORGatePrefab;

    [SerializeField] Transform GatePrefabParent;

    Button NOTGateButton;
    Button ANDGateButton;
    Button ORGateButton;
    Button NANDGateButton;
    Button NORGateButton;
    Button XORGateButton;
    Button XNORGateButton;

    private void Awake()
    {
        NOTGateButton = transform.GetChild(0).GetComponent<Button>();
        ANDGateButton = transform.GetChild(1).GetComponent<Button>();
        ORGateButton = transform.GetChild(2).GetComponent<Button>();
        NANDGateButton = transform.GetChild(3).GetComponent<Button>();
        NORGateButton = transform.GetChild(4).GetComponent<Button>();
        XORGateButton = transform.GetChild(5).GetComponent<Button>();
        XNORGateButton = transform.GetChild(6).GetComponent<Button>();
    }

    private void Start()
    {
        NOTGateButton.onClick.AddListener(NOTButton);
        ANDGateButton.onClick.AddListener(ANDButton);
        ORGateButton.onClick.AddListener(ORButton);
        NANDGateButton.onClick.AddListener(NANDButton);
        NORGateButton.onClick.AddListener(NORButton);
        XORGateButton.onClick.AddListener(XORButton);
        XNORGateButton.onClick.AddListener(XNORButton);
    }

    void NOTButton()
    {
        InstantiateGate(NOTGatePrefab);
        DisableGatesPanel();
    }

    void ANDButton()
    {
        InstantiateGate(ANDGatePrefab);
        DisableGatesPanel();
    }

    void ORButton()
    {
        InstantiateGate(ORGatePrefab);
        DisableGatesPanel();
    }

    void NANDButton()
    {
        InstantiateGate(NANDGatePrefab);
        DisableGatesPanel();
    }

    void NORButton()
    {
        InstantiateGate(NORGatePrefab);
        DisableGatesPanel();
    }

    void XORButton()
    {
        InstantiateGate(XORGatePrefab);
        DisableGatesPanel();
    }

    void XNORButton()
    {
        InstantiateGate(XNORGatePrefab);
        DisableGatesPanel();
    }

    void InstantiateGate(GameObject gatePrefab)
    {
        GlobalData._CurrentGatePrefab = Instantiate(gatePrefab, GatePrefabParent);
    }

    void DisableGatesPanel()
    {
        GlobalData._IsToolsPanelCreated = false;
        GlobalData._IsLogicGateDragging = true;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !GlobalData._IsToolsPanelCreated)
        {
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
}
