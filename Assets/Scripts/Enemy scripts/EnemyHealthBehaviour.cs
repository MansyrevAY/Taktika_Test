using UnityEngine;

[RequireComponent(typeof(EnemyBehaviour))]
public class EnemyHealthBehaviour : MonoBehaviour
{
    public PlayerStatsSO playerStats;
    public GameEventSO deathEvent;

    [SerializeField]
    [ReadOnly]
    private int currentHealth;
    private int gold;
    private EnemyBehaviour behaviour;

    private void Awake() => behaviour = GetComponent<EnemyBehaviour>();

    private void Start()
    {
        currentHealth = behaviour.stats.ThisWaveHP;
        gold = behaviour.stats.ThisWaveGoldPerKill;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            CallDeath();
    }

    private void CallDeath()
    {
        playerStats.IncreaseGoldBy(gold);
        deathEvent.Raise();
        Destroy(gameObject);
    }
}
