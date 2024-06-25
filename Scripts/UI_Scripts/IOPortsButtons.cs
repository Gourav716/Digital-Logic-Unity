using UnityEngine;
using UnityEngine.UI;

public class IOPortsButtons : MonoBehaviour
{
    [SerializeField] GameObject _2BitIOPrefab;
    [SerializeField] GameObject _4BitIOPrefab;
    [SerializeField] GameObject _8BitIOPrefab;
    [SerializeField] GameObject _16BitIOPrefab;

    [SerializeField] Transform IOPrefabParent;

    Button _2PortButton;
    Button _4PortButton;
    Button _8PortButton;
    Button _16PortButton;

    private void Awake()
    {
        _2PortButton = transform.GetChild(0).GetComponent<Button>();
        _4PortButton = transform.GetChild(1).GetComponent<Button>();
        _8PortButton = transform.GetChild(2).GetComponent<Button>();
        _16PortButton = transform.GetChild(3).GetComponent<Button>();
    }

    private void Start()
    {
        _2PortButton.onClick.AddListener(Create2PortIO);
        _4PortButton.onClick.AddListener(Create4PortIO);
        _8PortButton.onClick.AddListener(Create8PortIO);
        _16PortButton.onClick.AddListener(Create16PortIO);
    }

    void Create2PortIO()
    {
        InstantiateIO(_2BitIOPrefab);
        DisablePortPanel();
    }

    void Create4PortIO()
    {
        InstantiateIO(_4BitIOPrefab);
        DisablePortPanel();
    }

    void Create8PortIO()
    {
        InstantiateIO(_8BitIOPrefab);
        DisablePortPanel();
    }

    void Create16PortIO()
    {
        InstantiateIO(_16BitIOPrefab);
        DisablePortPanel();
    }

    void InstantiateIO(GameObject IOPrefab)
    {
        GlobalData._CurrentIOPrefab = Instantiate(IOPrefab, IOPrefabParent);
    }

    void DisablePortPanel()
    {
        GlobalData._IsToolsPanelCreated = false;
        GlobalData._IsIOPrefabDragging = true;
        gameObject.SetActive(false);
        GlobalData.DeactivateComponentUI();
    }
}
