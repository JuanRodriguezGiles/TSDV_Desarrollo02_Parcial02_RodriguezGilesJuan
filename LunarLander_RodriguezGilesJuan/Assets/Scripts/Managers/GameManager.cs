using MonoBehaviourSingletonScript;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum Scenes
{
    SplashScreen,
    MainMenu,
    GamePlay
}
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene((int)Scenes.GamePlay);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}