using System;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] internal float sliedeSpeed;
    [SerializeField] internal float rotationSpeed;

    [SerializeField] internal Transform visualObject;
    [SerializeField] internal float fallSpeed;

    [SerializeField] internal GameplayManager gameplayManager;

    CharacterState currentState;
    internal CharacterMovementState movementState;
    CharacterFallState fallState;

    Vector2 startPos = new Vector2(.5f, .5f);

    private void Awake()
    {

        fallState = GetComponent<CharacterFallState>();
        movementState = GetComponent<CharacterMovementState>();
    }
    private void OnEnable()
    {
        SwitchState(movementState);
        ResetPosition();
        gameplayManager.OnLevelUp += ResetPosition;
        gameplayManager.OnExitGameplay += OnExit;
    }
    private void OnDisable()
    {
        gameplayManager.OnLevelUp -= ResetPosition;
        gameplayManager.OnExitGameplay -= OnExit;
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
        gameplayManager.Fall();
        fallState.fallPos = pos;
        SwitchState(fallState);
    }

    internal void GetCoin(CoinType type)
    {
        gameplayManager.GetPoints(type);
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }
    void OnExit()
    {
        enabled = false;
    }

   
}
