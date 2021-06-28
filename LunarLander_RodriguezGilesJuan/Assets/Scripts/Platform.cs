using UnityEngine;
public class Platform : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D other)
    {
        float angle = other.transform.rotation.eulerAngles.z;

        if (angle > 350f || angle < 10f)
        {
            Debug.Log("pog");
        }
    }
}
