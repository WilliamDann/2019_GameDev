using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog {
    public string name;
    public string text;
    
    public Dialog(string name, string text) {
        this.name = name;
        this.text = text;
    }
}

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text contentText;

    public List<Dialog> texts = new List<Dialog>();

    public Animator animator;

    // Put some text in the text queue
    public void Say(Dialog say) {
        texts.Add(say);
    }

    // Say multiple texts
    public void Say(Dialog[] say) {
        texts.AddRange(say);
    }

    // Advance the text queue
    public void Next() {
       animator.SetBool("show", true);
        
        if (texts.Count == 0) {
            animator.SetBool("show", false);            
            nameText.text    = "";
            contentText.text = "";

            return;
        }

        Dialog d = texts[0];

        nameText.text    = d.name;
        contentText.text = d.text;

        texts.RemoveAt(0);
    }

    void Start() {
        // animator.SetBool("show", false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Next();
        }
    }
}
