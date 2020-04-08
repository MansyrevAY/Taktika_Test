using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GetHPFromStats : MonoBehaviour
{
    public PlayerStatsSO PlayerStats;

    private TextMeshProUGUI hpText;

    private void Awake() => hpText = GetComponent<TextMeshProUGUI>();
    private void Update() => hpText.text = PlayerStats.CurrentHP.ToString();
}
