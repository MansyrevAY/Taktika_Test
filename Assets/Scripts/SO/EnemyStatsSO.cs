using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "Scriptable Object/Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    [Header("Starting Stats")]
    [SerializeField]
    private int startingHP;
    [SerializeField]
    private int startingDamage;
    [SerializeField]
    private int startingGoldPerKill;

    [Header("Increments")]
    [SerializeField]
    private int hpIncrement;
    [SerializeField]
    private int damageIncrement;
    [SerializeField]
    private int goldIncrement;

    [Header("Current stats")]
    [SerializeField]
    [ReadOnly]
    private int _thisWaveHP;
    public int ThisWaveHP => _thisWaveHP;

    [SerializeField]
    [ReadOnly]
    private int _thisWaveDamage;
    public int ThisWaveDamage => _thisWaveDamage;

    [SerializeField]
    [ReadOnly]
    private int _thisWaveGoldPerKill;
    public int ThisWaveGoldPerKill => _thisWaveGoldPerKill;

    public void IncreaseRandomStat()
    {
        int r = Random.Range(0, 3);

        switch (r)
        {
            case 0:
                _thisWaveHP += hpIncrement;
                break;
            case 1:
                _thisWaveDamage += damageIncrement;
                break;
            case 2:
                _thisWaveGoldPerKill += goldIncrement;
                break;
            default:
                break;
        }
    }

    public void Reset()
    {
        _thisWaveDamage = startingDamage;
        _thisWaveGoldPerKill = startingGoldPerKill;
        _thisWaveHP = startingHP;
    }
}
