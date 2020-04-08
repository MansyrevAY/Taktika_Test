using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Waypoint startingWaypoint;
    public float spawnDelay;
    public List<EnemyToSpawn> enemies;

    private int waveNumber = 0;

    // Called by NewWaveEvent
    public void StartSpawningWave()
    {
        waveNumber++;
        StartCoroutine(SpawnAllEnemies());
    }

    private IEnumerator SpawnAllEnemies()
    {
        Random.InitState((int)Time.time);

        foreach (EnemyToSpawn enemy in enemies)
        {
            for(int i = 0; i < waveNumber + Random.Range(0, enemy.amountIncrement); i++)
            {
                Spawn(enemy);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

    private void Spawn(EnemyToSpawn e)
    {
        GameObject spawnedEnemy = Instantiate(e.prefab, transform.position, Quaternion.identity, EnemyToSpawn.parent.transform);
        WaypointNavigator navigator = spawnedEnemy.GetComponent<WaypointNavigator>();

        navigator.currentWaypoint = startingWaypoint;
    }

    [System.Serializable]
    public class EnemyToSpawn
    {
        private static GameObject _parent;
        public static GameObject parent
        {
            get
            {
                if (_parent == null)
                {
                    _parent = new GameObject("Enemies root");
                }

                return _parent;
            }
        }

        [SerializeField]
        public GameObject prefab;
        [SerializeField]
        public int amountIncrement;
    }
}




