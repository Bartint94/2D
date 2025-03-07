using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    CharacterManager characterManager;
    internal float vertical;
    internal float horizontal;

    bool isWSAD = true;

    private void Awake()
    {
        characterManager = GetComponent<CharacterManager>();    
    }
    public void SetStering(int value)
    {
        if(value == 0)
        {
            isWSAD = true;
        }
        if(value == 1)
        {
            isWSAD = false;
        }
    }

    internal void UpdateInput()
    {
        vertical = 0f;
        horizontal = 0f;


        if (isWSAD)
            WSAD();
        else
            Arrows();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            characterManager.gameplayManager.ExitGameplay();
        }
    }

    void Arrows()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1f;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vertical = -1f;

        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            horizontal -= 1f;
        }
    }

    void WSAD()
    {
        if (Input.GetKey(KeyCode.W))
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
