using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public string sceneTarget;

    void OnCollisionEnter(Collision col) {
        SceneManager.LoadScene(sceneTarget);
    }
}
