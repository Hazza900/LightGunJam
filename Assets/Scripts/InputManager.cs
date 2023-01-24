using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput playerInput;
    bool shootInput;
    bool reloadInput;



    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Player.Cursor.Enable();
        playerInput.Player.Shoot.Enable();
        playerInput.Player.Shoot.performed += ctx => shootInput = true;
        playerInput.Player.Shoot.canceled += ctx => shootInput = false;
        playerInput.Player.Reload.Enable();
        playerInput.Player.Reload.performed += ctx => reloadInput = true;
        playerInput.Player.Reload.canceled += ctx => reloadInput = false;
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

    public bool GetRClickInput()
    {
        return reloadInput;
    }

    public bool GetLClickInput()
    {
        return shootInput;
    }
}
