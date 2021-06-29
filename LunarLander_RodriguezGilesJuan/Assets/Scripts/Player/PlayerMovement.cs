using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _thrustersStrenght;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _gravity;
    Rigidbody2D _rigidbody;
    PlayerStats _stats;
    ParticleSystem _particleSystem;
    void OnEnable()
    {
        GameManager.onLevelLoad += OnLevelLoad;
    }
    void OnDisable()
    {
        GameManager.onLevelLoad -= OnLevelLoad;
    }
    void Start()
    {
        _stats = GetComponent<PlayerStats>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = _gravity;
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _particleSystem.Stop();
    }
    void Update()
    {
        if (PauseControl.gameIsPaused) return;
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && _stats.fuel > 0)
        {
            _rigidbody.AddRelativeForce(new Vector2(0, _thrustersStrenght));
            _stats.fuel -= 0.1f;
            if (!_particleSystem.IsAlive())
                _particleSystem.Play();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            _rigidbody.rotation += _rotationSpeed;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            _rigidbody.rotation -= _rotationSpeed;

        _stats.xSpeed = _rigidbody.velocity.x;
        _stats.ySpeed = _rigidbody.velocity.y;
        _stats.altitude = (int)transform.position.y * 10;
    }
    void OnLevelLoad()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
    }
}