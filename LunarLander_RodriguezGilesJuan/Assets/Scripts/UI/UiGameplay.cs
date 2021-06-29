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
        score.text = _stats.score.ToString();
    }
    void Update()
    {
        _time += Time.deltaTime;
        time.text = "Time " + Mathf.Round(_time);
        fuel.text = "Fuel " + _stats.fuel;
        altitude.text = "Altitude " + _stats.altitude;
        xSpeed.text = "Horizontal Speed " + _stats.xSpeed;
        ySpeed.text = "Vertical Speed " + _stats.ySpeed;
    }
    public void LoadMainMenuScene()
    {
        GameManager.Get().LoadMainMenuScene();
    }
    public void OnPlayerLanded(int value)
    {
        _landingMenu.gameObject.SetActive(true);
        _landingMenu.NextLevelButton.gameObject.SetActive(true);
        _landingMenu.resultText.text = "Succesful Landing!";
        score.text = _stats.score.ToString();
    }
    public void OnPlayerCrashed()
    {
        _landingMenu.gameObject.SetActive(true);
        _landingMenu.NextLevelButton.gameObject.SetActive(false);
        _landingMenu.resultText.text = "Crashed!";
    }
}