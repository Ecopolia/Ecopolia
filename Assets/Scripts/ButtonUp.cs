using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUp : MonoBehaviour
{
    private GameManager gm;
    public Building buildingUp;
    public Building buildingToReplace;
    
    // Quand un clique sur l'objet déclenche la fonction
    private void OnMouseDown(){
        if(gm.UpBuilding(buildingUp, buildingToReplace)){
            Destroy(this.gameObject);
        }
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
