using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameManagerSO GameManager;

    public void StopLevel() => GameManager.PauseGame();
}
