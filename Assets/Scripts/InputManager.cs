using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Player.Cursor.Enable();
        playerInput.Player.Shoot.Enable();
        playerInput.Player.Reload.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Cursor.Disable();
        playerInput.Player.Shoot.Disable();
        playerInput.Player.Reload.Disable();
    }

    public Vector2 GetMouseInput()
    {
        return playerInput.Player.Cursor.ReadValue<Vector2>();
    }

    public float GetRClickInput()
    {
        return playerInput.Player.Reload.ReadValue<float>();
    }

    public float GetLClickInput()
    {
        return playerInput.Player.Shoot.ReadValue<float>();
    }
}
