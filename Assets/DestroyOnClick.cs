using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    public float delay = 0.00f;

    void OnMouseOver() {
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            Destroy(gameObject, delay);
        }
    }
}
