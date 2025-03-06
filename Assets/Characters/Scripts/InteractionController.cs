using UnityEngine;
public interface IInteractable
{
    void Interaction(CharacterManager manager);
}
public class InteractionController : MonoBehaviour
{
    CharacterManager manager;
    private void Awake()
    {
        manager = GetComponent<CharacterManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interaction(manager);
        }
    }
}
