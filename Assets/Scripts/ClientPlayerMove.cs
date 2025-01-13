using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClientPlayerMove : NetworkBehaviour
{
    [SerializeField]
    CharacterController m_CharacterController;
    [SerializeField]
    PlayerInput m_PlayerInput;
    
    [SerializeField]
    Transform m_CameraFollow;

    private void Awake()
    {
        m_CharacterController.enabled = false;
        m_PlayerInput.enabled = false;
    }
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        enabled = IsClient;
        
        if (!IsOwner)
        {
            enabled = false;
            m_CharacterController.enabled = false;
            m_PlayerInput.enabled = false;
            return;
        }
        
        m_CharacterController.enabled = true;
        m_PlayerInput.enabled = true;
        
        
    }
}
