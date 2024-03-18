using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameInput : MonoBehaviour
{
    public static GameInput Instance {get; private set;}
    private PlayerInputActions playerInputActions;
    void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }
    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadDefaultValue();
        return mousePos;
    }
    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
