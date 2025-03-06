using UnityEngine;

internal class CharacterFallState : CharacterState
{
    internal Vector2 fallPos;
    public override void BeforeSwitch()
    {
        manager.visualObject.localScale = Vector3.one;
        manager.transform.position = Vector3.zero;
        rb.simulated = true;
    }

    public override void Init()
    {
        rb.simulated = false;
    }

    public override void OnFixedUpdate()
    {
        
    }

    public override void OnUpdate()
    {
        FallIllusion();
    }
    void FallIllusion()
    {
        if (manager.visualObject.localScale.magnitude > .1f)
        {
            manager.visualObject.localScale = Vector3.Lerp(manager.visualObject.localScale, Vector3.zero, manager.fallSpeed * Time.deltaTime);
            LerpToCenter();
        }
        else
        {
            manager.SwitchState(manager.movementState);
        }
    }
    void LerpToCenter()
    {
        transform.position = Vector2.Lerp(transform.position, fallPos, Time.deltaTime * manager.fallSpeed);
    }
}
