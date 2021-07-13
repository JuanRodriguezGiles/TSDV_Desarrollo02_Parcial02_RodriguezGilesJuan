using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MonoBehaviourSingletonScript;
public class HighScoreManager : MonoBehaviourSingleton<HighScoreManager>
{
    public List<int> _highScores = new List<int>(5);
    void OnEnable()
    {
        Terrain.onTerrainCrash += UpdateHighScores;
        Platform.onPlatformCrash += UpdateHighScores;

        if (!File.Exists("playerHighScores.dat")) return;
        FileStream fs;
        BinaryFormatter bf = new BinaryFormatter();
        fs = File.OpenRead("playerHighScores.dat");
        _highScores = (List<int>)bf.Deserialize(fs);
        fs.Close();
    }
    void OnDisable()
    {
        Terrain.onTerrainCrash -= UpdateHighScores;
        Platform.onPlatformCrash -= UpdateHighScores;
    }
    void OnApplicationQuit()
    {
        FileStream fs;
        BinaryFormatter bf = new BinaryFormatter();
        fs = File.OpenWrite("playerHighScores.dat");
        bf.Serialize(fs, _highScores);
        fs.Close();
    }
    void UpdateHighScores()
    {
        int score = FindObjectOfType<PlayerStats>().score;
        if (_highScores.Count < 5)
        {
            _highScores.Add(score);
            _highScores.Sort();
        }
        else
        {
            for (int i = 0; i < _highScores.Count; i++)
            {
                if (score <= _highScores[i]) continue;
                if (i - 1 >= 0)
                    _highScores[i - 1] = _highScores[i];
                _highScores[i] = score;
            }
            _highScores.Sort();
        }
    }
    void UpdateHighScores(int value)
    {
        int score = FindObjectOfType<PlayerStats>().score;
        if (_highScores.Count < 5)
        {
            _highScores.Add(score);
            _highScores.Sort();
        }
        else
        {
            for (int i = 0; i < _highScores.Count; i++)
            {
                if (score <= _highScores[i]) continue;
                if (i - 1 >= 0)
                    _highScores[i - 1] = _highScores[i];
                _highScores[i] = score;
            }
            _highScores.Sort();
        }
    }
}