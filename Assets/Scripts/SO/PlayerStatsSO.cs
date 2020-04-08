using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "Scriptable Object/Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    [Header("Starting stats")]
    [ReadOnly]
    [SerializeField]
    private int maxHP;
    public int startingMaxHP => maxHP;
    [ReadOnly]
    [SerializeField]
    private int startingGold;
    public int StartingGold => startingGold;

    [Header("Current stats")]
    [ReadOnly]
    [SerializeField]
    private int _currentHP;
    public int CurrentHP => _currentHP;

    [ReadOnly]
    [SerializeField]
    private int _currentGold;
    public int Gold => _currentGold;

    [ReadOnly]
    [SerializeField]
    private int _enemiesKilled;
    public int EnemiesKilled => _enemiesKilled;

    [Header("Events")]
    public GameEventSO levelLost;

    public void DecreaseHPBy(int amount)
    {
        
        if (_currentHP - amount <= 0)
        {
            _currentHP = 0;
            levelLost.Raise();
        }
        else
            _currentHP -= amount;
    }

    public void IncreaseGoldBy(int amount) => _currentGold += amount;
    public void DecreaseGoldBy(int amount) => _currentGold -= amount;
    public void OneEnemyKilled() => _enemiesKilled++;

    // Called by event listening to LevelStartEvent
    public void Reset()
    {
        _currentHP = maxHP;
        _currentGold = startingGold;
        _enemiesKilled = 0;
    }
}
