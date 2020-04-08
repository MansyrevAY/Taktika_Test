using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GetGoldFromStats : MonoBehaviour
{
    public PlayerStatsSO PlayerStats;

    private TextMeshProUGUI goldText;

    private void Awake() => goldText = GetComponent<TextMeshProUGUI>();
    private void Update() => goldText.text = PlayerStats.Gold.ToString();
}
