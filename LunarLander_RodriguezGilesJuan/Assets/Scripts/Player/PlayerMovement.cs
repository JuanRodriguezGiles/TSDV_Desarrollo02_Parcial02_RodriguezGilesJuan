using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _thrustersStrenght;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _gravity;
    Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            _rigidbody.AddRelativeForce(new Vector2(0, _thrustersStrenght));
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _rigidbody.rotation += _rotationSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _rigidbody.rotation -= _rotationSpeed;
        }
    }
}