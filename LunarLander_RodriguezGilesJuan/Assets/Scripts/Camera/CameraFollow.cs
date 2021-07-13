using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider2D mapBounds;

    private float _xMin, _xMax, _yMin, _yMax;
    private float _camY, _camX;
    private float _camOrthsize;
    private float _cameraRatio;
    private Camera _mainCam;

    private void Start()
    {
        _xMin = mapBounds.bounds.min.x;
        _xMax = mapBounds.bounds.max.x;
        _yMin = mapBounds.bounds.min.y;
        _yMax = mapBounds.bounds.max.y;
        _mainCam = GetComponent<Camera>();
        _camOrthsize = _mainCam.orthographicSize;
        _cameraRatio = (_xMax + _camOrthsize) / 2.0f;
    }
    void FixedUpdate()
    {
        _camY = Mathf.Clamp(followTransform.position.y, _yMin + _camOrthsize, _yMax - _camOrthsize);
        _camX = Mathf.Clamp(followTransform.position.x, _xMin + _cameraRatio, _xMax - _cameraRatio);
        this.transform.position = new Vector3(_camX, _camY, this.transform.position.z);
    }
}