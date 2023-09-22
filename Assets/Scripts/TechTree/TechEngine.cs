using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechEngine : MonoBehaviour
{
    private GameManager gm;
    private GameObject[] buildings;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        increaseMoney(10);
    }
    public void increaseMoney(int percent, string id = null){

        foreach (Building building in gm.buildings)
        {
            if(id != null){
                if(id == building.id){
                    building.moneyIncrease = (percent/building.moneyIncrease) * 100;
                }
            } else {
                building.moneyIncrease = (percent/building.moneyIncrease) * 100;
            }
  
        }
        
    }
}
