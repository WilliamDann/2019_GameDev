using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable {
    void Interact();
}

public class InteractableObject : MonoBehaviour, IInteractable
{
    public Color[] colors;
    public int index = 0;

    public void Interact() {
        gameObject.GetComponent<Renderer>().material.color = colors[index];
        index++;

        if (index >= colors.Length) { index = 0; }
    }
}
