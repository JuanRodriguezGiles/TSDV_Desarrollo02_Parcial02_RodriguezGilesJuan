using System;
using UnityEngine;
public class Terrain : MonoBehaviour
{
    public static event Action onTerrainCrash;
    void OnCollisionEnter2D(Collision2D collision)
    {
        onTerrainCrash?.Invoke();
    }
}