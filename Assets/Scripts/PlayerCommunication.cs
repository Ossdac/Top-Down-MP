using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCommunication : NetworkBehaviour
{
    public NetworkVariable<int> emoji = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Owner);

    public GameObject[] emojiObjects;

    public void OnHeart(InputValue value)
    {
        emoji.Value = 0;
    }

    public void OnBrokenHeart(InputValue value)
    {
        emoji.Value = 1;
    }

    public void OnHappy(InputValue value)
    {
        emoji.Value = 2;
    }

    public void OnAngry(InputValue value)
    {
        emoji.Value = 3;
    }
    
    public void OnNeutral(InputValue value)
    {
        emoji.Value = 4;
    }


    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        emoji.OnValueChanged += NewEmotion;
    }

    private void NewEmotion(int previousValue, int newValue)
    {
        int emojiIndex = newValue;
        for (int i = 0; i < emojiObjects.Length; i++)
        {
            emojiObjects[i].SetActive(i == emojiIndex);
        }
    }
}