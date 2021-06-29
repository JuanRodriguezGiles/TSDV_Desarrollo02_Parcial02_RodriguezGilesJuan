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
    LandingMenu _landingMenu;
    void OnEnable()
    {
        GameManager.onPlayerLanded += OnPlayerLanded;
        GameManager.onPlayerCrashed += OnPlayerCrashed;
    }
    void Start()
    {
        _stats = FindObjectOfType<PlayerStats>();
        _landingMenu = FindObjectOfType<LandingMenu>();
        _landingMenu.gameObject.SetActive(false);
        score.text = "Score " + _stats.score.ToString();
    }
    void Update()
    {
        _time += Time.deltaTime;
        time.text = "Time " + Mathf.Round(_time);
        fuel.text = "Fuel " + Mathf.Round(_stats.fuel);
        altitude.text = "Altitude " + _stats.altitude;
        xSpeed.text = "Horizontal Speed " + Mathf.Round(Mathf.Abs(_stats.xSpeed) * 10);
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
    public void OnPlayerLanded(int value)
    {
        _landingMenu.gameObject.SetActive(true);
        _landingMenu.NextLevelButton.gameObject.SetActive(true);
        _landingMenu.resultText.text = "Succesful Landing!";
        score.text = "Score " + _stats.score.ToString();
    }
    public void OnPlayerCrashed()
    {
        _landingMenu.gameObject.SetActive(true);
        _landingMenu.NextLevelButton.gameObject.SetActive(false);
        _landingMenu.resultText.text = "Crashed!";
    }
}