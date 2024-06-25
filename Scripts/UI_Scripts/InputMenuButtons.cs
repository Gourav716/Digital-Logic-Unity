using UnityEngine;
using UnityEngine.UI;

public class InputMenuButtons : MonoBehaviour
{
    IOMenu IOMenu;

    Button propertiesButton;
    Button deleteButton;

    private void Awake()
    {
        IOMenu = GetComponentInParent<IOMenu>();

        propertiesButton = transform.GetChild(0).GetComponent<Button>();
        deleteButton = transform.GetChild(1).GetComponent<Button>();
    }

    private void Start()
    {
        propertiesButton.onClick.AddListener(PropertiesButton);
        deleteButton.onClick.AddListener(DeleteButton);
    }

    void PropertiesButton()
    {
        IOMenu.DisableContextPanel();
        Debug.Log("Properties");
    }

    void DeleteButton()
    {
        IOMenu.DisableContextPanel();
        Destroy(IOMenu.currentObject);
    }
}
