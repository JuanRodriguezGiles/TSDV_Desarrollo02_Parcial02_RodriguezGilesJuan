using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _thrustersStrenght;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _gravity;
    PlayerStats _stats;
    Rigidbody2D _rigidbody;
    ParticleSystem _particleSystem;
    ConstantForce2D _constantForce;
    Vector3 _startPos;
    void OnEnable()
    {
        Levels.onLevelLoad += OnLevelLoad;
    }
    void OnDisable()
    {
        Levels.onLevelLoad -= OnLevelLoad;
    }
    void Start()
    {
        _stats = GetComponent<PlayerStats>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _constantForce = GetComponent<ConstantForce2D>();
        _rigidbody.gravityScale = _gravity;
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _particleSystem.Stop();
        _startPos = transform.position;
    }
    void Update()
    {
        if (UiPauseControl.gameIsPaused) return;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            _constantForce.force = transform.up * _thrustersStrenght;
            _stats.fuel -= 1f * Time.deltaTime;
        }
        else
            _constantForce.force = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            _rigidbody.rotation += _rotationSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            _rigidbody.rotation -= _rotationSpeed * Time.deltaTime;
        else
            _constantForce.torque = 0;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            _particleSystem.Play();
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space))
            _particleSystem.Stop();

        _stats.xSpeed = _rigidbody.velocity.x;
        _stats.ySpeed = _rigidbody.velocity.y;
        _stats.altitude = transform.position.y;
    }
    void OnLevelLoad()
    {
        transform.position = _startPos;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
        _constantForce.torque = 0;
        _constantForce.force = Vector2.zero;
    }
}