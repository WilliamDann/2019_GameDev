using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWalk : MonoBehaviour
{
    public PathInstruction[] points;
    public int index = 0;
    public float speed;
    public bool move = true;

    void Update() {
        if (move) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, points[index].point.transform.position, step);

            if (Vector3.Distance(transform.position, points[index].point.transform.position) < 0.001f) {
                index++;
                if (index >= points.Length) index = 0;
            }
        }
    }

    // Stop walking on interaction
    // TODO Sync with DialogManager
    void OnTriggerStay(Collider col) {
        if (col.transform.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.E)) {
                move = false;
            }
        }
    }
}

[System.Serializable]
public class PathInstruction {
    public GameObject point;
    public float pause;

    public PathInstruction(GameObject point, float pause) {
        this.point = point;
        this.pause = pause;
    }
}