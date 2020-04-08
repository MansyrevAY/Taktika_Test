using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEventSO))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameEventSO gameEvent = (GameEventSO)target;

        if(GUILayout.Button("Raise event"))
        {
            gameEvent.Raise();
        }
    }
}
