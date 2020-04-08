using UnityEngine;

public class PlayerBaseBehaviuor : MonoBehaviour
{
    public PlayerStatsSO playerStats;

    // Called by entering enemies
    public void TakeDamage(int amount) => playerStats.DecreaseHPBy(amount);

    public void OnEnemyKilled() => playerStats.OneEnemyKilled();
}
