using UnityEngine;

public class Wire : MonoBehaviour
{
    CreateWire CreateWire;

    public MeshCollider meshCollider;

    bool isMeshNull;

    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
    }

    private void Start()
    {
        CreateWire = GetComponentInParent<CreateWire>();

        isMeshNull = false;
    }

    // Destroy wire after it is connected by clicking right mouse button when hovering over wire.
    private void OnMouseOver()
    {
        if (!CreateWire.isWireDragging && !GlobalData._IsWireDragging && Input.GetMouseButtonDown(1))
        {
            CreateWire.lineCount--;
            
            CreateWire.lineRendererList.RemoveAt(CreateWire.lineCount);
            CreateWire.wirePrefabList.RemoveAt(CreateWire.lineCount);

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (GlobalData._CurrentGateMoveComponent != null)
        {
            if (GlobalData._CurrentGateMoveComponent.isGateDragging && !isMeshNull)
            {
                meshCollider.sharedMesh = null;
                isMeshNull = true;
                GlobalData._CurrentIOMoveComponent = null;
            }

            if (!GlobalData._CurrentGateMoveComponent.isGateDragging && isMeshNull)
            {
                Mesh mesh = new();
                gameObject.GetComponent<LineRenderer>().BakeMesh(mesh);
                meshCollider.sharedMesh = mesh;

                isMeshNull = false;
            }
        }

        if (GlobalData._CurrentIOMoveComponent != null)
        {
            if (GlobalData._CurrentIOMoveComponent.isIODragging && !isMeshNull)
            {
                meshCollider.sharedMesh = null;
                isMeshNull = true;
                GlobalData._CurrentGateMoveComponent = null;
            }

            if (!GlobalData._CurrentIOMoveComponent.isIODragging && isMeshNull)
            {
                Mesh mesh = new();
                gameObject.GetComponent<LineRenderer>().BakeMesh(mesh);
                meshCollider.sharedMesh = mesh;

                isMeshNull = false;
            }
        }

        // Destroy wire while it is being dragged after creation and not connected.
        if (CreateWire.isWireDragging && Input.GetMouseButtonDown(1))
        {
            CreateWire.lineCount--;

            Destroy(CreateWire.wirePrefabList[CreateWire.lineCount]);

            CreateWire.lineRendererList.RemoveAt(CreateWire.lineCount);
            CreateWire.wirePrefabList.RemoveAt(CreateWire.lineCount);

            CreateWire.isWireDragging = false;
            GlobalData._IsWireDragging = false;
        }
    }

    public void DestroyWire()
    {
        CreateWire.lineCount--;

        CreateWire.lineRendererList.RemoveAt(CreateWire.lineCount);
        CreateWire.wirePrefabList.RemoveAt(CreateWire.lineCount);

        Destroy(gameObject);
    }
}
