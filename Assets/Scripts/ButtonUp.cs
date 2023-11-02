using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUp : MonoBehaviour
{
    private GameManager gm;
    public Building buildingUp;
    public Building buildingToReplace;
    
    private void OnMouseDown(){
        gm.ConstructBuilding(buildingUp, null, buildingToReplace);
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
