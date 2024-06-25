using System.Collections.Generic;
using UnityEngine;

public class CreateWire : MonoBehaviour
{
    public Wire Wire;

    [SerializeField] GameObject wire;
    public SpriteRenderer inputSprite;
    public List<LineRenderer> lineRendererList = new();
    public List<GameObject> wirePrefabList = new();

    Vector2 mousePosition;

    [HideInInspector] public bool isWireDragging;
    public int lineCount;

    private void Awake()
    {
        inputSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        inputSprite.color = GlobalData.inputOffColor;

        lineCount = 0;

        isWireDragging = false;

        GlobalData._IsWireDragging = false;
    }

    private void OnMouseDown()
    {
        if (!GlobalData._IsWireDragging && !GlobalData._IsContextPanelCreated)
        {
            wirePrefabList.Add(Instantiate(wire, transform.position, transform.rotation, transform));
            lineCount++;

            lineRendererList.Add(wirePrefabList[lineCount - 1].GetComponent<LineRenderer>());
            lineRendererList[lineCount - 1].SetPosition(0, Vector3.zero);

            lineRendererList[lineCount - 1].startColor = inputSprite.color;
            lineRendererList[lineCount - 1].endColor = inputSprite.color;

            Wire = transform.GetChild(lineCount - 1).GetComponentInChildren<Wire>();

            GlobalData._CurrentPort = gameObject;

            isWireDragging = true;
            GlobalData._IsWireDragging = true;
        }
    }

    private void Update()
    {
        if (isWireDragging)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            lineRendererList[lineCount - 1].SetPosition(1, new Vector3(mousePosition.x, mousePosition.y));
        }
    }
}
