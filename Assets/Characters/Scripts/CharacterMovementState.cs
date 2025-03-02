using UnityEngine;

internal class CharacterMovementState : CharacterState
{
    public float rotation;
    public override void Init()
    {
        
    }

    public override void OnUpdate()
    {
        input.UpdateInput();
        Rotation();

    }
    public override void BeforeSwitch()
    {
        
    }
    public override void OnFixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 dir = new Vector2(input.horizontal, input.vertical).normalized;// + transform.right * input.horizontal;
        rb.linearVelocity += dir * manager.speed;

    }
    void Rotation()
    {
        if(input.vertical > 0f)
        {
            rotation = Mathf.LerpAngle(rotation, 90f, manager.rotationSpeed * Time.deltaTime);
        }
        if (input.vertical < 0f)
        {
            rotation = Mathf.LerpAngle(rotation, -90f, manager.rotationSpeed * Time.deltaTime);
        }
        if(input.horizontal > 0f)
        {
            rotation = Mathf.LerpAngle(rotation, 0f, manager.rotationSpeed * Time.deltaTime);
        }
        if (input.horizontal < 0f)
        {
            rotation = Mathf.LerpAngle(rotation, 180f, manager.rotationSpeed * Time.deltaTime);
        }

        manager.visualObject.rotation = Quaternion.Euler(0f,0f, rotation);
    }


}