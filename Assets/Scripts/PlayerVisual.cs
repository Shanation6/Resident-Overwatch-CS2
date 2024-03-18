using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVisual : MonoBehaviour
{
    private const string IS_RUNNING = "IsRunning";
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
        AdjustPlayerFacingDirection();
    }
    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerPosition = Player.Instance.GetPlayerScreenPosition();
        if (mousePos.x < playerPosition.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
