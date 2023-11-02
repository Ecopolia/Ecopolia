using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechEngineScript : MonoBehaviour
{

    public GameObject buildMenu;
    public void OnMouseDown()
    {
        buildMenu.SetActive(!buildMenu.gameObject.activeSelf);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
