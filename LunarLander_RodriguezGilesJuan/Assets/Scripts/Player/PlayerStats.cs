using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public float fuel;
    [HideInInspector] public int score;
    [HideInInspector] public float altitude;
    [HideInInspector] public float xSpeed;
    [HideInInspector] public float ySpeed;
    float _startFuel;
    void OnEnable()
    {
        Platform.onPlatformLand += AddScore;
        Levels.onLevelLoad += ResetStats;
    }
    void OnDisable()
    {
        Platform.onPlatformLand -= AddScore;
        Levels.onLevelLoad -= ResetStats;
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