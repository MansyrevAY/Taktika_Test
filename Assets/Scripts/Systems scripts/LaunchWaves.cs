using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responcible for launching new waves
/// </summary>
public class LaunchWaves : MonoBehaviour
{
    public GameEventSO newWaveEvent;
    public List<EnemyStatsSO> allStats;

    protected float waveDelay;

    private float lastTimeSpawned = 0;
    private bool levelStarted = false;

    // Start is called before the first frame update
    void Start() => waveDelay = System.Int32.Parse(GetFromConfig.GetElement("waveDelay"));

    // Update is called once per frame
    void Update()
    {
        if((Time.time - lastTimeSpawned > waveDelay) && levelStarted)
        {
            UpdateStats();
            newWaveEvent.Raise();
            lastTimeSpawned = Time.time;
        }
    }

    private void UpdateStats()
    {
        foreach (EnemyStatsSO statsSO in allStats)
        {
            statsSO.IncreaseRandomStat();
        }
    }

    // Called by listener to StartLevelEvent
    public void OnLevelStarted()
    {
        lastTimeSpawned = Time.time;
        newWaveEvent.Raise();

        levelStarted = true;
    }
}
