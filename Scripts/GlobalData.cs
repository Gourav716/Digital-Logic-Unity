using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static GateMove _CurrentGateMoveComponent;
    public static IOPortMove _CurrentIOMoveComponent;

    public static GameObject _CurrentPort;
    public static GameObject _CurrentIOPrefab;
    public static GameObject _CurrentGatePrefab;

    public static Color inputOffColor = new(0.24f, 0.2f, 0.2f, 1.0f);
    public static Color inputOnColor = new(0.8f, 0.2f, 0.2f, 1.0f);

    public static Stack<GameObject> _ToolsUIObjects = new();

    public static bool _IsContextPanelCreated;
    public static bool _IsToolsPanelCreated;

    public static bool _IsWireDragging;
    public static bool _IsIOPrefabDragging;
    public static bool _IsLogicGateDragging;

    public static void DeactivateComponentUI()
    {
        if (_ToolsUIObjects.Count > 0)
        {
            while (_ToolsUIObjects.Count > 0)
            {
                _ToolsUIObjects.Pop().SetActive(false);
            }
        }
    }
}
