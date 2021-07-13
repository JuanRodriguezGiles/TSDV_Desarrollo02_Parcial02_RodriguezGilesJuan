using System;
using UnityEngine;
public class Platform : MonoBehaviour
{
    public int points;
    public static event Action<int> onPlatformLand;
    public static event Action onPlatformCrash;
    public void OnTriggerStay2D(Collider2D other)
    {
        float angle = other.transform.rotation.eulerAngles.z;
        PlayerStats stats = other.GetComponent<PlayerStats>();
        if ((angle > 350f || angle < 10f) && stats.ySpeed < 3)
            onPlatformLand?.Invoke(points);
        else
            onPlatformCrash?.Invoke();
    }
}