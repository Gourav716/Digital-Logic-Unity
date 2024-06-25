using UnityEngine;
using UnityEngine.UI;

public class GateMenuButton : MonoBehaviour
{
    IOMenu IOMenu;

    Button deleteButton;

    private void Awake()
    {
        IOMenu = GetComponentInParent<IOMenu>();

        deleteButton = transform.GetChild(0).GetComponent<Button>();
    }

    private void Start()
    {
        deleteButton.onClick.AddListener(DeleteButton);
    }

    void DeleteButton()
    {
        IOMenu.DisableContextPanel();
        Destroy(IOMenu.currentObject);
    }
}
