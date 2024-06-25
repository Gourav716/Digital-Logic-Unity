using TMPro;
using UnityEngine;

public class OutputValue : MonoBehaviour
{
    ConnectWire ConnectWire;
    TextMeshPro outputValue;

    private void Start()
    {
        ConnectWire = transform.GetChild(0).GetComponent<ConnectWire>();
        outputValue = transform.GetChild(1).GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        if (ConnectWire.connectedLine != null)
        {
            if (ConnectWire.connectedLine.startColor == GlobalData.inputOnColor)
            {
                outputValue.text = "1";
            }
            else
            {
                outputValue.text = "0";
            }
        }
    }
}
