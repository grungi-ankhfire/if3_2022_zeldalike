using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{

    private float verticalSpeed;

    public override void Interact() {
        verticalSpeed = 5f;
    }

    void Update() {
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
    }

}
