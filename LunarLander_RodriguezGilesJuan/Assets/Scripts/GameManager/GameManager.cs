using System;
using System.Collections.Generic;
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
    #region EVENTS
    public static event Action<int> onPlayerLanded;
    public static event Action onPlayerCrashed;
    public static event Action onLevelLoad;
    public void OnPlayerLanded(int value)
    {
        onPlayerLanded?.Invoke(value);
        Time.timeScale = 0f;
    }
    public void OnPlayerCrashed()
    {
        onPlayerCrashed?.Invoke();
        Time.timeScale = 0f;
    }
    public void OnLevelLoad()
    {
        onLevelLoad?.Invoke();
        Time.timeScale = 1f;
    }
    #endregion
}