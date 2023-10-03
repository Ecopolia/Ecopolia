using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    private SceneManagerScript sm;
    public string Scene;

    void Start() {
        sm = FindObjectOfType<SceneManagerScript>();
    }
    private void OnMouseDown(){
        sm.LoadScene(Scene);
    }
}
