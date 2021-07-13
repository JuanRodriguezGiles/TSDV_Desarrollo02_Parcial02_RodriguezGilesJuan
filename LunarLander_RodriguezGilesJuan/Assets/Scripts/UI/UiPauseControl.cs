using UnityEngine;
public class UiPauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    void OnEnable()
    {
        Platform.onPlatformLand += Pause;
        Platform.onPlatformCrash += Pause;
        Levels.onLevelLoad += Pause;
        Terrain.onTerrainCrash += Pause;
    }
    void OnDisable()
    {
        Platform.onPlatformLand -= Pause;
        Platform.onPlatformCrash -= Pause;
        Levels.onLevelLoad -= Pause;
        Terrain.onTerrainCrash -= Pause;
    }
    public void Pause()
    {
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }
    public void Pause(int num)
    {
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }
    void PauseGame()
    {
        if (gameIsPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1;
    }
}