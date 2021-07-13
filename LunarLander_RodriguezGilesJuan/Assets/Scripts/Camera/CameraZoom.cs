using System.Collections;
using UnityEngine;
public class CameraZoom : MonoBehaviour
{
    public Transform player;
    public float zoomInDistance;
    public float zoomOutDistance;
    Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }
    void FixedUpdate()
    {
        if (player.position.y < zoomInDistance)
            StartCoroutine(ZoomIn());
        else if (player.position.y > zoomOutDistance)
            StartCoroutine(ZoomOut());
    }
    IEnumerator ZoomIn()
    {
        while (_camera.orthographicSize > 2)
        {
            _camera.orthographicSize -= 0.15f * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator ZoomOut()
    {
        while (_camera.orthographicSize < 5)
        {
            _camera.orthographicSize += 0.15f * Time.deltaTime;
            yield return null;
        }
    }
}