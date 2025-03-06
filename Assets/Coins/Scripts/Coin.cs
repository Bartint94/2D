using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    public void Interaction(CharacterManager manager)
    {
        manager.GetCoin();
    }
}
