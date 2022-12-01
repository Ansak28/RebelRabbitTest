using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, ExamenDeProgramacionRebelRabbit.IPlayerActions
{
    public static InputManager Instance {get; private set;}
    public Vector2 movement;
    private ExamenDeProgramacionRebelRabbit mInputPlayer;
    private event EventHandler OnJumpHandler;
    private event EventHandler OnRollHandler;
     private void Awake() 
    {
        Instance = this;
        mInputPlayer= new ExamenDeProgramacionRebelRabbit();
        mInputPlayer.Player.SetCallbacks(this);
    }
    private void OnEnable() 
    {
        mInputPlayer.Enable();
    }
    private void OnDisable() 
    {
        mInputPlayer.Disable();
    }
   
    public void OnFire(InputAction.CallbackContext context)
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        OnJumpHandler?.Invoke(this,EventArgs.Empty);
    }
    public void AddOnJumpHandler(EventHandler handler)
    {
        OnJumpHandler += handler;
    }
    public void DeleteOnJumpHandler(EventHandler handler)
    {
        OnJumpHandler -= handler;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        OnRollHandler?.Invoke(this,EventArgs.Empty);
    }
    public void AddOnRollHandler(EventHandler handler)
    {
        OnRollHandler += handler;
    }

}
