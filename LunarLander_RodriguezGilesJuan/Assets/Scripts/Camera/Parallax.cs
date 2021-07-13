using UnityEngine;
public class Parallax : MonoBehaviour
{
    float _lenght;
    float _startPos;
    Camera _camera;
    public float parallaxAmmount;
    void Start()
    {
        _camera = Camera.main;
        _startPos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void FixedUpdate()
    {
        float distance = _camera.transform.position.x * parallaxAmmount;
        transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);
    }
}
