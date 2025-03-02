using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    internal float vertical;
    internal float horizontal;
    private void Awake()
    {
        
    }

    internal void UpdateInput()
    {
        vertical = 0f;
        horizontal = 0f;

        if(Input.GetKey(KeyCode.W))
        {
            vertical = 1f;
            
        }
      
        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }
       

        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1f;
            
        }
       

        if (Input.GetKey(KeyCode.A))
        {
            horizontal -= 1f;
        }
       
    }
}
