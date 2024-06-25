using TMPro;
using UnityEngine;

public class InputToggle : MonoBehaviour
{
    SpriteRenderer mainInputSprite;
    TextMeshPro inputValue;

    Vector3 originalPosition;

    bool isOnInputPort;
    bool hasInputMoved;

    private void Start()
    {
        mainInputSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        inputValue = transform.GetChild(1).GetComponent<TextMeshPro>();

        mainInputSprite.color = GlobalData.inputOffColor;
        inputValue.text = "0";

        isOnInputPort = false;
        hasInputMoved = false;
    }

    private void OnMouseUp()
    {
        if (!GlobalData._IsWireDragging && !hasInputMoved && !GlobalData._IsContextPanelCreated && !GlobalData._IsIOPrefabDragging)
        {
            if (!isOnInputPort)
            {
                inputValue.text = "1";

                mainInputSprite.color = GlobalData.inputOnColor;

                isOnInputPort = true;
            }
            else
            {
                inputValue.text = "0";

                mainInputSprite.color = GlobalData.inputOffColor;

                isOnInputPort = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if (!GlobalData._IsWireDragging)
        {
            originalPosition = transform.parent.position;
            hasInputMoved = false;
        }
    }

    private void OnMouseDrag()
    {
        if (!GlobalData._IsContextPanelCreated && !GlobalData._IsWireDragging)
        {
            if (transform.parent.position != originalPosition)
            {
                hasInputMoved = true;
            }
        }
    }
}
