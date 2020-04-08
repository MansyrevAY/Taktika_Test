using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyStatsSO))]
public class EnemyStatsEditor : Editor
{ 
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();      

        EnemyStatsSO enemyStats = (EnemyStatsSO)target;

        if (GUILayout.Button("Increase random stat"))
        {
            enemyStats.IncreaseRandomStat();
        }
    }
}
