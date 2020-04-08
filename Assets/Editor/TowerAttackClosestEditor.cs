using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TowerAttack))]
public class TowerAttackClosestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TowerAttack tower = (TowerAttack)target;

        if (!Application.isPlaying)
            return;

        if (GUILayout.Button("Upgrade tower"))
        {
            tower.Upgrade();
        }
    }
}
