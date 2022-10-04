using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public float moveSpeed = 3;

    private InputAction moveAction;
    private PlayerInputActions actions;

    private Rigidbody rb;

    void Start() {
        actions = new PlayerInputActions();
        moveAction = actions.Player.Move;
        moveAction.Enable();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Vector2 moveDirection = -moveAction.ReadValue<Vector2>();

        Vector2 movement = moveDirection * moveSpeed * Time.fixedDeltaTime;
        Vector3 translation = new Vector3(movement.x, 0, movement.y);
        rb.MovePosition(transform.position + translation);

        if (moveDirection != Vector2.zero) {
            transform.forward = translation;
        }

    }

    public void Activate(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("ACTIVATE!!!!!!!!");
        }
    }

    public void Move(InputAction.CallbackContext context) {
        Debug.Log("Move");
    }

}
