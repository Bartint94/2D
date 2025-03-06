using System;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] internal float sliedeSpeed;
    [SerializeField] internal float rotationSpeed;

    [SerializeField] internal Transform visualObject;
    [SerializeField] internal float fallSpeed;


    CharacterState currentState;
    internal CharacterMovementState movementState;
    CharacterFallState fallState;


    private void Awake()
    {
        fallState = GetComponent<CharacterFallState>();
        movementState = GetComponent<CharacterMovementState>();
    }
    private void OnEnable()
    {
        SwitchState(movementState);
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (!currentState) return;

        currentState.OnUpdate();
    }
   
    private void FixedUpdate()
    {
        if (!currentState) return;

        currentState.OnFixedUpdate();
    }
    internal void SwitchState(CharacterState nextState)
    {
        if (currentState != null)
            currentState.BeforeSwitch();
        currentState = nextState;
        currentState.Init();
    }
    public void Fall(Vector2 pos)
    {
        fallState.fallPos = pos;
        SwitchState(fallState);
    }

    internal void GetCoin()
    {
        throw new NotImplementedException();
    }
}
