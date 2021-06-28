using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _thrustersStrenght;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _gravity;
    Rigidbody2D _rigidbody;
    PlayerStats _stats;
    void Start()
    {
        _stats = GetComponent<PlayerStats>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = _gravity;
    }
    void Update()
    {
        if (PauseControl.gameIsPaused) return;
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) && _stats.fuel > 0)
        {
            _rigidbody.AddRelativeForce(new Vector2(0, _thrustersStrenght));
            _stats.fuel -= 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            _rigidbody.rotation += _rotationSpeed;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            _rigidbody.rotation -= _rotationSpeed;

        _stats.xSpeed = _rigidbody.velocity.x;
        _stats.ySpeed = _rigidbody.velocity.y;
    }
}