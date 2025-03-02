using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] internal float speed;
    [SerializeField] internal float rotationSpeed;
    internal float currentRotationVel;



    CharacterState currentState;
    CharacterMovementState movementState;
    [SerializeField] internal Transform visualObject;

    private void Awake()
    {
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
}
