using UnityEngine;

public class Not_Gate : MonoBehaviour
{
    ConnectWire ConnectWire;
    CreateWire CreateWire;

    private void Start()
    {
        ConnectWire = transform.GetChild(0).GetComponent<ConnectWire>();
        CreateWire = transform.GetChild(1).GetComponent<CreateWire>();
    }

    private void Update()
    {
        if (ConnectWire.isConnected)
        {
            if (ConnectWire.outputSprite.color == GlobalData.inputOnColor)
            {
                CreateWire.inputSprite.color = GlobalData.inputOffColor;
            }
            else
            {
                CreateWire.inputSprite.color = GlobalData.inputOnColor;
            }
        }
        else
        {
            CreateWire.inputSprite.color = GlobalData.inputOffColor;
        }
    }
}
