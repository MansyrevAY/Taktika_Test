using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GetUpgradeCostFromStats : MonoBehaviour
{
    public TowerStatsSO PlayerStats;

    private TextMeshProUGUI upgradeCostText;

    private void Awake() => upgradeCostText = GetComponent<TextMeshProUGUI>();
    private void Update() => upgradeCostText.text = PlayerStats.UpgradeCost.ToString();
}

