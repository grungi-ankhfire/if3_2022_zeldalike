using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rupee : MonoBehaviour
{

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PickUp(other.GetComponent<Character>());
        }
    }

    void PickUp(Character character) {
        character.rupees += 1;
        Destroy(gameObject);
    }

}
