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
    public static event Action onPlayerLanded;
    public static event Action onPlayerCrashed;
    public void OnPlayerLanded()
    {
        onPlayerLanded?.Invoke();
    }
    public void OnPlayerCrashed()
    {
        onPlayerCrashed?.Invoke();
    }
    #endregion
}