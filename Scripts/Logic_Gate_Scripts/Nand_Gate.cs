using UnityEngine;

public class Nand_Gate : MonoBehaviour
{
    CreateWire CreateWire;
    ConnectWire ConnectWire_1;
    ConnectWire ConnectWire_2;

    private void Start()
    {
        ConnectWire_1 = transform.GetChild(0).GetComponent<ConnectWire>();
        ConnectWire_2 = transform.GetChild(1).GetComponent<ConnectWire>();
        CreateWire = transform.GetChild(2).GetComponent<CreateWire>();
    }

    private void Update()
    {
        if (ConnectWire_1.isConnected && ConnectWire_2.isConnected)
        {
            if (ConnectWire_1.outputSprite.color == GlobalData.inputOnColor && ConnectWire_2.outputSprite.color == GlobalData.inputOnColor)
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
