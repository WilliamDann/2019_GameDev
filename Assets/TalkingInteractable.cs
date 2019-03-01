using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingInteractable : MonoBehaviour, IInteractable
{
    public DialogManager dialogManager;
    public Dialog[] say;

    public bool oneShot = false;
    bool said = false;
    
    public void Interact() {
        if (oneShot && said) return;

        dialogManager.Say(say);
        dialogManager.Next();
        said = true;
    }
}
