using UnityEngine;
public enum CoinType { silver= 1, gold= 2 }
public class Coin : MonoBehaviour, IInteractable
{
    [SerializeField] CoinType coinType;
    public void Interaction(CharacterManager manager)
    {
        SoundManager.Instance.PlaySFX("coins");
        manager.GetCoin(coinType);
        Destroy(gameObject);
    }
}
