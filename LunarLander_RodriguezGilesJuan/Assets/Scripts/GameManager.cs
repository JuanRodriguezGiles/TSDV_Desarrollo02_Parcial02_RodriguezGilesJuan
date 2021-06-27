using MonoBehaviourSingletonScript;
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
        SceneManager.LoadScene((int) Scenes.MainMenu);
    }
}