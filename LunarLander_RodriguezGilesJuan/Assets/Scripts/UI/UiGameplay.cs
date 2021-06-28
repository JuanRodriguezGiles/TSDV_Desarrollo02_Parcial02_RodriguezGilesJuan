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
    void Start()
    {
        _stats = FindObjectOfType<PlayerStats>();
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
}