using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClientPlayerMove : NetworkBehaviour
{
    [SerializeField]
    private PlayerInput m_PlayerInput;
    [SerializeField]
    private Player m_Player;
    [SerializeField]
    private Transform m_CameraFollow;

    private void Awake()
    {
        m_PlayerInput.enabled = false;
        
    }
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        enabled = IsClient;

        m_Player.SetPlayerOne(IsHost == IsOwner);
        
        
        if (!IsOwner)
        {
            enabled = false;
            m_PlayerInput.enabled = false;
            return;
        }
        
        m_PlayerInput.enabled = true;
        
        
    }
}
