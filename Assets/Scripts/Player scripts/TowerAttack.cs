using UnityEngine;

/// <summary>
/// Attacks first enemy, which enters trigger collider
/// </summary>
[RequireComponent(typeof(Tower))]
[RequireComponent(typeof(Collider2D))]
public class TowerAttack : MonoBehaviour
{
    #region Inspector
    [Header("Current stats")]
    [SerializeField]
    [ReadOnly]
    private int _damage;
    public int Damage => _damage;

    [SerializeField]
    [ReadOnly]
    private int _attackSpeed;
    public int AttackSpeed => _attackSpeed;

    //[SerializeField]
    //private int _range;
    //public int Range => _range;
    #endregion

    private Tower tower;
    private EnemyHealthBehaviour currentTarget;

    private float lastTimeAttacked = 0;
    private float waitAfterAttack;

    private void Awake()
    {
        tower = GetComponent<Tower>();
        tower.EnemyOutOfRange += GetNextTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        _damage = tower.towerStats.Damage;
        _attackSpeed = tower.towerStats.AttackSpeed;
        tower.TowerUpgraded += Upgrade;
    }

    public void Upgrade()
    {
        _damage += tower.towerStats.DamageIncrement;
        _attackSpeed += tower.towerStats.AttackSpeedIncrement;
    }

    // Update is called once per frame
    void Update()
    {
        if(tower.enemies.Count > 0 && currentTarget == null)
        {
            GetNextTarget();
        }

        waitAfterAttack = 1 / (float)AttackSpeed * 50;

        if(Time.time - lastTimeAttacked > waitAfterAttack && currentTarget != null)
        {
            lastTimeAttacked = Time.time;
            DealDamage();
        }
    }

    private void GetNextTarget()
    {
        if (tower.enemies.Count > 0)
            currentTarget = tower.enemies[0];
    }

    private void DealDamage() => currentTarget.TakeDamage(Damage);

    private void OnDrawGizmos()
    {
        if (currentTarget == null)
            return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, currentTarget.transform.position);
    }    
}
