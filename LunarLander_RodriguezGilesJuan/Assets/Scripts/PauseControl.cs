using UnityEngine;
public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public void Pause()
    {
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}