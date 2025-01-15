using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 

    private Vector2 _moveInput; 

    public void OnMove(InputValue movementValue)
    {
        _moveInput = movementValue.Get<Vector2>();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(_moveInput.x, _moveInput.y, 0f) * (moveSpeed * Time.deltaTime);
        transform.position += movement;
    }
}
