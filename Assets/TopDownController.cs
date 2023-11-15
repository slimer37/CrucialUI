using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownController : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] float _crossTime;
    [SerializeField] float _minWalkAnimSpeed;

    Vector2 _input;
    Rigidbody2D _rb;

    Vector2 _direction;

    string _queuedState;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _input = Vector3.ClampMagnitude(_input, 1);

        if (_input.sqrMagnitude > 0)
        {
            _direction = _input;
        }

        HandleAnimation();
    }

    void HandleAnimation()
    {
        if (_input.x != 0)
        {
            _sprite.flipX = _input.x > 0;
        }

        string state;

        if (Mathf.Abs(_direction.x) > Mathf.Abs(_direction.y))
        {
            state = "side_";
        }
        else if (_direction.y > 0)
        {
            state = "up_";
        }
        else
        {
            state = "down_";
        }

        if (_input.magnitude > _minWalkAnimSpeed)
        {
            state += "walk";
        }
        else
        {
            state += "idle";
        }

        if (_queuedState != state)
        {
            _animator.CrossFadeInFixedTime(state, _crossTime);
            _queuedState = state;
        }
    }

    void FixedUpdate()
    {
        _rb.velocity = _input * _speed;
    }
}
