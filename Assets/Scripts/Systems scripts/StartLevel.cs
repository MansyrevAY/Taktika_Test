using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Responsible for starting all level mechanics
/// </summary>
public class StartLevel : MonoBehaviour
{
    public PlayerStatsSO playerStats;
    public GameEventSO startLevelEvent;
    public List<EnemyStatsSO> allEnemyStats;

    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;

    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetStats();
        startLevelEvent.Raise();
    }

    private void ResetStats()
    {
        foreach(EnemyStatsSO enemyStats in allEnemyStats)
        {
            enemyStats.Reset();
        }

        playerStats.Reset();
    }    
}
