using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GetEnemiesKilledFromStats : MonoBehaviour
{
    public PlayerStatsSO PlayerStats;

    private TextMeshProUGUI enemiesKilledText;

    private void Awake() => enemiesKilledText = GetComponent<TextMeshProUGUI>();
    private void Update() => enemiesKilledText.text = PlayerStats.EnemiesKilled.ToString();
}
