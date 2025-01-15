using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private bool _isPlayerOne;
    
    [SerializeField] SpriteRenderer _spriteRenderer;
    
    public void SetPlayerOne(bool isPlayerOne)
    {
        _isPlayerOne = isPlayerOne;
        name = isPlayerOne ? "Player One" : "Player Two";
        transform.position = isPlayerOne ? new Vector3(-1f, 0f, 0f) : new Vector3(1f, 0f, 0f);
        _spriteRenderer.color = isPlayerOne ? Color.red : Color.blue;
    }
}
