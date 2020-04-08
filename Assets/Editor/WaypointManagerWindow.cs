using UnityEngine;
using UnityEditor;

public class WaypointManagerWindow : EditorWindow
{
    public Transform waypointRoot;

    [MenuItem("Tools/Waypoint Editor")]
    public static void Open() => GetWindow<WaypointManagerWindow>();

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));

        EditorGUILayout.BeginVertical("box");
        DrawButtons();
        EditorGUILayout.EndVertical();
        
        obj.ApplyModifiedProperties();
    }

    protected void DrawButtons()
    {
        if(GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }

        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
            CreateButtonsOnSelectedWaypoint();
        }
    }    

    protected void CreateWaypoint()
    {
        GameObject waypointObject = GetWaypoint();

        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
        if (waypointRoot.childCount > 1)
        {
            waypoint.previousWaypoint = waypointRoot.GetChild(waypointRoot.childCount - 2).GetComponent<Waypoint>();
            waypoint.previousWaypoint.nextWaypoint = waypoint;

            waypoint.transform.position = waypoint.previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
        }

        Selection.activeGameObject = waypoint.gameObject;

    }

    protected void CreateButtonsOnSelectedWaypoint()
    {
        if (GUILayout.Button("Create Waypoint Before"))
        {
            CreateWaypointBefore();
        }

        if (GUILayout.Button("Create Waypoint After"))
        {
            CreateWaypointAfter();
        }

        if (GUILayout.Button("Remove Waypoint"))
        {
            RemoveWaypoint();
        }
    }   

    private void CreateWaypointBefore()
    {
        GameObject waypointObj = GetWaypoint();

        Waypoint newWaypoint = waypointObj.GetComponent<Waypoint>();

        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        waypointObj.transform.position = selectedWaypoint.transform.position;
        waypointObj.transform.right = selectedWaypoint.transform.right;

        if(selectedWaypoint.previousWaypoint != null)
        {
            newWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
            selectedWaypoint.previousWaypoint.nextWaypoint = newWaypoint;
        }

        newWaypoint.nextWaypoint = selectedWaypoint;
        selectedWaypoint.previousWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newWaypoint.gameObject;
    }

    private void CreateWaypointAfter()
    {
        GameObject waypointObj = GetWaypoint();

        Waypoint newWaypoint = waypointObj.GetComponent<Waypoint>();

        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        waypointObj.transform.position = selectedWaypoint.transform.position;
        waypointObj.transform.right = selectedWaypoint.transform.right;

        newWaypoint.previousWaypoint = selectedWaypoint;

        if (selectedWaypoint.nextWaypoint != null)
        {
            selectedWaypoint.nextWaypoint.previousWaypoint = newWaypoint;
            newWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
        }

        selectedWaypoint.nextWaypoint = newWaypoint;
        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newWaypoint.gameObject;
    }

    private void RemoveWaypoint()
    {
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        if (selectedWaypoint.nextWaypoint != null)
        {
            selectedWaypoint.nextWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
        }

        if (selectedWaypoint.previousWaypoint != null)
        {
            selectedWaypoint.previousWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
            Selection.activeGameObject = selectedWaypoint.previousWaypoint.gameObject;
        }

        DestroyImmediate(selectedWaypoint.gameObject);
    }

    protected GameObject GetWaypoint()
    {
        GameObject waypointObj = new GameObject("Waypoint " + (waypointRoot.childCount + 1), typeof(Waypoint));
        waypointObj.transform.SetParent(waypointRoot, false);

        return waypointObj;
    }


}