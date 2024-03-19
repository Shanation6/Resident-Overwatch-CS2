using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    private PlayerInputActions playerInputActions;
    private Rigidbody2D rb;
    private float minMovement = 0.1f;
    private bool isRunning = false;
    public static Player Instance {get; private set;}
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector(); // получает вектор из gameinput
        rb.MovePosition(rb.position + inputVector * (_movingSpeed + Time.deltaTime)); // расчёт новой позиции игрока
        if (Mathf.Abs(inputVector.x) > minMovement || Mathf.Abs(inputVector.y) > minMovement)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
    public bool IsRunning()
    {
        return isRunning;
    }
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
    private void FixedUpdate()
    {
        HandleMovement(); // объявление метода
    }

}
