using UnityEngine;

internal abstract class CharacterState : MonoBehaviour
{
    internal Rigidbody2D rb;
    internal CharacterInput input;
    internal CharacterManager manager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        input = GetComponent<CharacterInput>();
        manager = GetComponent<CharacterManager>();
    }

    public abstract void Init();
    public abstract void OnUpdate();
    public abstract void OnFixedUpdate();
    public abstract void BeforeSwitch();

}