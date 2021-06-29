using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    [HideInInspector] public int score;
    public float fuel;
    [HideInInspector] public int altitude;
    [HideInInspector] public float xSpeed;
    [HideInInspector] public float ySpeed;
    float _startFuel;
    void OnEnable()
    {
        GameManager.onPlayerLanded += AddScore;
        GameManager.onLevelLoad += ResetStats;
    }
    void OnDisable()
    {
        GameManager.onPlayerLanded -= AddScore;
        GameManager.onLevelLoad -= ResetStats;
    }
    void Start()
    {
        _startFuel = fuel;
    }
    void AddScore(int value)
    {
        score += value;
    }
    void ResetStats()
    {
        fuel = _startFuel;
    }
}