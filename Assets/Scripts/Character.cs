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

    private Rigidbody rb;

    public Chest chest;
    public TextMeshProUGUI rubyText;

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
        if (context.performed && chest != null) {
            chest.Open();
        }
    }

    public void Move(InputAction.CallbackContext context) {
        Debug.Log("Move");
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Chest")) {
            chest = other.GetComponent<Chest>();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Chest")) {
            chest = null;
        }
    }

}
