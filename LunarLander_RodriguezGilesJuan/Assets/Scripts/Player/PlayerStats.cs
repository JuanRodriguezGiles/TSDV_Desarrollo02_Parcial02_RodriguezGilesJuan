using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public int score;
    public int fuel;
    public int altitude;
    public float xSpeed;
    public float ySpeed;
    int _startFuel;
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