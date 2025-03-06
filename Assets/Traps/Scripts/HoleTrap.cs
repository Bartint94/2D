using System.Collections;
using UnityEngine;

public class HoleTrap : MonoBehaviour, IInteractable
{
    public void Interaction(CharacterManager manager)
    {
        manager.Fall(new Vector2(transform.position.x,transform.position.y));
    }
    

    
}
