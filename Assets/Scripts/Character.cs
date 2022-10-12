using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class Character : MonoBehaviour
{
    public float moveSpeed = 3;

    private InputAction moveAction;
    private PlayerInputActions actions;

    private CharacterController controller;

    public Interactable currentInteractable;

    public TextMeshProUGUI rubyText;

    private float verticalSpeed = 0;

    private int _rupees;
    public int rupees
    {
        get { return _rupees; }
        set { 
            _rupees = value;
            rubyText.text = $"x {_rupees}";
        }
    }
    

    void Start() {
        actions = new PlayerInputActions();
        moveAction = actions.Player.Move;
        moveAction.Enable();
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        Vector2 moveDirection = -moveAction.ReadValue<Vector2>();

        if (!controller.isGrounded) {
            verticalSpeed += -9.81f * Time.deltaTime;
        } else {
            verticalSpeed = 0f;
        }
        
        Vector3 verticalMovement = new Vector3(0, verticalSpeed * Time.deltaTime, 0);

        Vector2 movement = moveDirection * moveSpeed * Time.deltaTime;
        Vector3 horizontalMovement = new Vector3(movement.x, 0, movement.y);
        
        controller.Move(horizontalMovement + verticalMovement);

        if (moveDirection != Vector2.zero) {
            transform.forward = horizontalMovement;
        }

    }

    public void Activate(InputAction.CallbackContext context) {
        if (context.performed && currentInteractable != null) {
            currentInteractable.Interact();
        }
    }

    public void Move(InputAction.CallbackContext context) {
        Debug.Log("Move");
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Interactable")) {
            currentInteractable = other.GetComponent<Interactable>();
        }

        // // Version alternative
        // Interactable interactable = other.GetComponent<Interactable>();
        // if (interactable != null) {
        //     currentInteractable = interactable;
        // }


    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Interactable")) {
            currentInteractable = null;
        }
    }

}
