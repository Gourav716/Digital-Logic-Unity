using UnityEngine;

public class ConnectWire : MonoBehaviour
{
    public CreateWire CreateWire;

    public SpriteRenderer outputSprite;
    public LineRenderer connectedLine;
    GameObject thisWire;

    public bool isConnected;

    private void Start()
    {
        outputSprite = GetComponent<SpriteRenderer>();
        outputSprite.color = GlobalData.inputOffColor;

        isConnected = false;
    }

    private void OnMouseDown()
    {
        if (GlobalData._IsWireDragging && !isConnected)
        {
            if (GlobalData._CurrentPort.TryGetComponent<CreateWire>(out CreateWire))
            {
                Vector3 lineEndPosition = transform.position - CreateWire.transform.position;
                CreateWire.lineRendererList[CreateWire.lineCount - 1].SetPosition(1, lineEndPosition);
                CreateWire.isWireDragging = false;

                thisWire = CreateWire.Wire.gameObject;
                connectedLine = CreateWire.lineRendererList[CreateWire.lineCount - 1];

                isConnected = true;
                GlobalData._IsWireDragging = false;

                Mesh mesh = new();
                CreateWire.lineRendererList[CreateWire.lineCount - 1].BakeMesh(mesh);
                CreateWire.Wire.meshCollider.sharedMesh = mesh;
            }
        }
    }

    private void Update()
    {
        if (connectedLine != null)
        {
            if (CreateWire.lineCount > 0 && !CreateWire.isWireDragging)
            {
                Vector3 lineEndPosition = transform.position - CreateWire.transform.position;
                connectedLine.SetPosition(1, lineEndPosition);
            }

            outputSprite.color = CreateWire.inputSprite.color;

            if (CreateWire.lineCount > 0)
            {
                connectedLine.startColor = CreateWire.inputSprite.color;
                connectedLine.endColor = CreateWire.inputSprite.color;
            }
        }
        else
        {
            outputSprite.color = GlobalData.inputOffColor;
            isConnected = false;
        }
    }

    private void OnDestroy()
    {
        if (CreateWire != null)
        {
            CreateWire.Wire.DestroyWire(thisWire);
        }
    }
}
