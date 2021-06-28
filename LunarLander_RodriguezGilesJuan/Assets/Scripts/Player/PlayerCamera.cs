using System.Collections;
using UnityEngine;
public class PlayerCamera : MonoBehaviour
{
    Camera _camera;
    float _hitDistance = 2;
    void Start()
    {
        _camera = Camera.main;
    }
    void FixedUpdate()
    {
        _camera.transform.position = transform.position + new Vector3(0, 0, -10);
        LayerMask terrain = LayerMask.GetMask("Terrain");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, _hitDistance, terrain);
        if (hit.collider != null)
        {
            StartCoroutine(ZoomIn());
        }
        else
        {
            StartCoroutine(ZoomOut());
        }
    }
    IEnumerator ZoomIn()
    {
        while (_camera.orthographicSize > 2)
        {
            _camera.orthographicSize -= 0.25f * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator ZoomOut()
    {
        while (_camera.orthographicSize < 5)
        {
            _camera.orthographicSize += 0.25f * Time.deltaTime;
            yield return null;
        }
    }
}