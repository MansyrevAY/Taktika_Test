using System.Collections.Generic;
using UnityEngine;

public delegate void emptyDelegate();

[SelectionBase]
public class Tower : MonoBehaviour
{
    public TowerStatsSO towerStats;
    public PlayerStatsSO playerStats;

    public event emptyDelegate EnemyOutOfRange;
    public event emptyDelegate TowerUpgraded;

    public List<EnemyHealthBehaviour> enemies;

    private void Awake() => enemies = new List<EnemyHealthBehaviour>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            EnemyHealthBehaviour enemyTakeDamage =
                collision.GetComponent<EnemyHealthBehaviour>();
            SubscribeEnemy(enemyTakeDamage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            EnemyHealthBehaviour enemyTakeDamage =
                collision.GetComponent<EnemyHealthBehaviour>();

            UnSubscribeEnemy(enemyTakeDamage);
            if(EnemyOutOfRange != null)
                EnemyOutOfRange.Invoke();
        }
    }

    private void SubscribeEnemy(EnemyHealthBehaviour health)
    {
        if (!enemies.Contains(health))
        {
            enemies.Add(health);
        }
    }

    private void UnSubscribeEnemy(EnemyHealthBehaviour health)
    {
        if (enemies.Contains(health))
        {
            enemies.Remove(health);
        }
    }

    public void OnTowerUpgraded()
    {
        if(playerStats.Gold - towerStats.UpgradeCost > 0)
        {
            playerStats.DecreaseGoldBy(towerStats.UpgradeCost);
            TowerUpgraded?.Invoke();
        }        
    }
}
