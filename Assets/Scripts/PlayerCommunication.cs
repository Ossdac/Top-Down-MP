using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCommunication : NetworkBehaviour
{
    public NetworkVariable<int> emoji = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    
    public GameObject[] emojiObjects;

    public void OnNeutral(InputValue value)
    {
        emoji.Value = 0;
    }
    
    public void OnHeart(InputValue value)
    {
        emoji.Value = 1;
    }
    
    public void OnBrokenHeart(InputValue value)
    {
        emoji.Value = 2;
    }
    
    public void OnHappy(InputValue value)
    {
        emoji.Value = 3;
    }
    
    public void OnAngry(InputValue value)
    {
        emoji.Value = 4;
    }


    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        emoji.OnValueChanged += NewEmotion;
    }

    private void NewEmotion(int previousvalue, int newvalue)
    {
        switch (emoji.Value)
        {
            case 0:
                foreach (GameObject emoji in emojiObjects)
                {
                    emoji.SetActive(false);
                }
                break;
            case 1:
                for (int i = 0; i < emojiObjects.Length; i++)
                {
                    emojiObjects[i].SetActive(i == 0);
                }
                break;
            case 2:
                for (int i = 0; i < emojiObjects.Length; i++)
                {
                    emojiObjects[i].SetActive(i == 1);
                }
                break;
            case 3:
                for (int i = 0; i < emojiObjects.Length; i++)
                {
                    emojiObjects[i].SetActive(i == 2);
                }
                break;
            case 4:
                for (int i = 0; i < emojiObjects.Length; i++)
                {
                    emojiObjects[i].SetActive(i == 3);
                }
                break;
        }
    }
}
