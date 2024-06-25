using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GlobalData._IsToolsPanelCreated = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GlobalData._IsToolsPanelCreated = false;
    }
}
