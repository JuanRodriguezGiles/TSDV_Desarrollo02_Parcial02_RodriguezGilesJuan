using System.Collections.Generic;
using UnityEngine;
public class Levels : MonoBehaviour
{
    public List<GameObject> levels;
    int _activeLevel;
    public void LoadNextLevel()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].SetActive(false);
        }
        if (_activeLevel < levels.Count-1)
            _activeLevel++;
        else
            _activeLevel = 0;
        levels[_activeLevel].SetActive(true);
        GameManager.Get().OnLevelLoad();
    }
}