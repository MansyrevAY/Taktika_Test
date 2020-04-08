using UnityEngine;

[CreateAssetMenu(fileName ="Tower Stats", menuName = "Scriptable Object/Tower Stats")]
public class TowerStatsSO : ScriptableObject
{
    [Header("Stats")]
    [SerializeField]
    private int damage;
    public int Damage { get => damage; }

    [Range(20, 80)]
    [SerializeField]
    private int attackSpeed;
    public int AttackSpeed { get => attackSpeed; }

    [SerializeField]
    private int upgradeCost;
    public int UpgradeCost { get => upgradeCost; }

    [Header("Increments")]
    [SerializeField]
    private int damageIncrement;
    public int DamageIncrement { get => damageIncrement; }

    [SerializeField]
    private int attackSpeedincrement;
    public int AttackSpeedIncrement { get => attackSpeedincrement; }



}
