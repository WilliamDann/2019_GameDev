using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IPuzzle {
    void StartPuzzle();
    bool CheckPuzzle();
    void EndPuzzle(bool result);
}

public class TestPuzzle : MonoBehaviour, IPuzzle, IInteractable
{
    public float time;
    public GameObject puzzleObject;

    GameObject instance;
    Text textClock;
    float dTime;

    // Start the puzzle
    public void StartPuzzle() {
        if (instance) return;
        
        instance = (GameObject)Instantiate(puzzleObject, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2)), puzzleObject.transform.rotation);
        instance.transform.position = new Vector3(instance.transform.position.x, instance.transform.position.y, -1);
        textClock = instance.GetComponentInChildren<Text>();

        dTime = time;
    }

    // check if the puzzle is completed
    public bool CheckPuzzle() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PuzzleTarget");
        if (objs.Length == 0) return true;
        else return false;
    }

    // TODO make this do something
    public void EndPuzzle(bool result) {
        if (result) {
            print("Puzzle passed!");
        } else {
            print("Puzzle failed!");
        }

        Destroy(instance);
    }

    public void Interact() {
        StartPuzzle();
    }

    // Run the puzzle
    void Update() {
        if (instance) {
            dTime -= Time.deltaTime;
            textClock.text = dTime.ToString("0.00");

            if (dTime <= 0.00f) {
                EndPuzzle(false);
            } else {
                if(CheckPuzzle()) {
                    EndPuzzle(true);
                }
            }
        }
    }
}
