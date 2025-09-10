using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class SidescrollerMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;

    private Vector2 _movement;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb2d.linearVelocityX = _movement.x;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = new(ctx.ReadValue<Vector2>().x * _speed, 0);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() != 1)
            return;
     
        _rb2d.linearVelocityY = _jumpHeight;
    }
}
