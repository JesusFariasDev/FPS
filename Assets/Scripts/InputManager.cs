using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor playerMotor;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        playerMotor = GetComponent<PlayerMotor>();
        onFoot.Jump.performed += ctx => playerMotor.Jump();
    }

    // Update is called once per frame
    void Update()
    {
        //tell the playermotor o move using the value from movement action
        playerMotor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable( )
    {
        onFoot.Disable();
    }
}
