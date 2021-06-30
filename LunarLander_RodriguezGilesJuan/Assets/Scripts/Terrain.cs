using UnityEngine;
public class Terrain : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        float angle = collision.transform.rotation.eulerAngles.z;

        if (!(angle > 350f || angle < 10f))
        {
            GameManager.Get().OnPlayerCrashed();
        }
    }
}