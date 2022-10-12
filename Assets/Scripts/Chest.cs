using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{

    public GameObject content;
    public UnityEvent onOpen;

    public void Open() {
        Destroy(gameObject, 5f);
        Instantiate(content, transform.position, transform.rotation);
        onOpen?.Invoke();
    }

}
