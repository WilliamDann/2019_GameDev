using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float maxSpeed;
    Animator animator;

    Rigidbody player;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool walked = false;
        if (Input.GetKey(KeyCode.W)) {
            player.AddForce(new Vector3(0, moveSpeed, 0));
            animator.SetBool("walking", true);
            animator.SetInteger("direction", 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            player.AddForce(new Vector3(-moveSpeed, 0, 0));
            animator.SetBool("walking", true);
            animator.SetInteger("direction", 3);
        }
        if (Input.GetKey(KeyCode.S)) {
            player.AddForce(new Vector3(0, -moveSpeed, 0));
            animator.SetBool("walking", true);
            animator.SetInteger("direction", 2);
        }
        if (Input.GetKey(KeyCode.D)) {
            player.AddForce(new Vector3(moveSpeed, 0, 0));
            animator.SetBool("walking", true);
            animator.SetInteger("direction", 1);
        }

        float speed = Vector3.Magnitude(player.velocity);
        
        if (speed > maxSpeed) {
            float brakeSpeed = speed - maxSpeed;
        
            Vector3 normalisedVelocity = player.velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;
        
            player.AddForce(-brakeVelocity);
        }

        if (speed < 0.05f) {
            animator.SetBool("walking", false);
        }
    }

    void OnTriggerStay(Collider col) {
        IInteractable interact = col.GetComponent<IInteractable>();
        
        if (interact != null) {
            if (Input.GetKeyDown(KeyCode.E)) {
                interact.Interact();
            }
        }
    }
}
