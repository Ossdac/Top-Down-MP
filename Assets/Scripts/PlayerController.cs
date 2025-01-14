using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 

    private Vector2 moveInput; 
    
    private void Awake()
    {
        Debug.Log("PlayerController script is active");
        PlayerInput playerInput = GetComponent<PlayerInput>();
        if (playerInput == null)
        {
            Debug.LogError("Player Input component is missing!");
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }

    private void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f) * (moveSpeed * Time.deltaTime);
        transform.position += movement;
    }
}
