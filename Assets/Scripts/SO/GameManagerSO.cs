using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Game Manager", menuName = "Scriptable Object/Game Manager")]
public class GameManagerSO : ScriptableObject
{
    public void PauseGame() => Time.timeScale = 0f;
    public void UnPauseGame() => Time.timeScale = 1f;
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        UnPauseGame();
    }
    public void ExitGame()
    {

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
        Application.Quit();
        #endif
    }


}
