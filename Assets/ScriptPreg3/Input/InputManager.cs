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
    private event EventHandler OnReturnFromRollHandler;
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
        if(context.started)
        {
            OnJumpHandler?.Invoke(this,EventArgs.Empty);
        }
    }
    public void AddOnJumpHandler(EventHandler handler)
    {
        OnJumpHandler = handler;
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
        if(context.performed)
        {
            OnRollHandler?.Invoke(this,EventArgs.Empty);
        }
        if (context.canceled)
        {
            OnReturnFromRollHandler?.Invoke(this,EventArgs.Empty);
        }
        
    }
    public void AddOnRollHandler(EventHandler handler)
    {
        OnRollHandler = handler;
    }
    public void AddOnReturnFromRollHandler(EventHandler handler)
    {
        OnReturnFromRollHandler = handler;
    }
    public void DeleteOnRollHandler(EventHandler handler)
    {
        OnRollHandler -= handler;
    }


}
