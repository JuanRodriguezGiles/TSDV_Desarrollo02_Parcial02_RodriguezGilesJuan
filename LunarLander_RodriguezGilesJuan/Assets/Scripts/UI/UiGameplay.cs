using TMPro;
using UnityEngine;
public class UiGameplay : MonoBehaviour
{
    PlayerStats _stats;
    float _time;
    public TMP_Text score;
    public TMP_Text time;
    public TMP_Text fuel;
    public TMP_Text altitude;
    public TMP_Text xSpeed;
    public TMP_Text ySpeed;
    UiLandingMenu _uiLandingMenu;
    void OnEnable()
    {
        Platform.onPlatformLand += OnPlayerLanded;
        Platform.onPlatformCrash += OnPlayerCrashed;
        Terrain.onTerrainCrash += OnPlayerCrashed;
    }
    void Start()
    {
        _stats = FindObjectOfType<PlayerStats>();
        _uiLandingMenu = FindObjectOfType<UiLandingMenu>();
        _uiLandingMenu.gameObject.SetActive(false);
        score.text = "Score " + _stats.score.ToString();
    }
    void Update()
    {
        _time += Time.deltaTime;
        time.text = "Time " + Mathf.Round(_time);
        fuel.text = "Fuel " + Mathf.Round(_stats.fuel);
        altitude.text = "Altitude " + _stats.altitude.ToString("0.00");
        xSpeed.text = "Horizontal Speed " + Mathf.Round(_stats.xSpeed * 10);
        ySpeed.text = "Vertical Speed " + Mathf.Round(Mathf.Abs(_stats.ySpeed) * 10);
    }
    public void LoadMainMenuScene()
    {
        GameManager.Get().LoadMainMenuScene();
    }
    public void ExitGame()
    {
        GameManager.Get().ExitGame();
    }
    void OnPlayerLanded(int value)
    {
        _uiLandingMenu.gameObject.SetActive(true);
        _uiLandingMenu.NextLevelButton.gameObject.SetActive(true);
        _uiLandingMenu.resultText.text = "Succesful Landing!";
        score.text = "Score " + _stats.score.ToString();
    }
    void OnPlayerCrashed()
    {
        _uiLandingMenu.gameObject.SetActive(true);
        _uiLandingMenu.NextLevelButton.gameObject.SetActive(false);
        _uiLandingMenu.resultText.text = "Crashed!";
        foreach (var VARIABLE in _uiLandingMenu.scores)
        {
            VARIABLE.text = "";
        }
        for (int i = 0; i < HighScoreManager.Get()._highScores.Count; i++)
        {
            _uiLandingMenu.scores[i].text = HighScoreManager.Get()._highScores[i].ToString();
        }
    }
}