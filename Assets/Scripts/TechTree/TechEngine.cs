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
        // Exemple la commande se lance direct on start si tu l'attache a un gameobject sur la scene
        // les changements se font sur l'object dans le dossier prefabs et buildings du coup
        // si tu met pas d'id ca increase sur tout buildings, sympa pour faire un upgrade all
        //increaseMoney(10,"5dfae78f-b9f3-43ff-a2d6-ad51316a4b3f");
    }
    public void increaseMoney(int percent, string id = null){
        Debug.Log("ici");
        Debug.Log(gm.buildingsPrefabs.Count);
        if(id != null){
            foreach (Building building in gm.buildingsPrefabs)
            {
            
                if(id == building.id){
                    Debug.Log(building.moneyIncrease);
                    building.moneyIncrease = Mathf.RoundToInt(building.moneyIncrease * (1 + percent / 100.0f));
                    Debug.Log(building.moneyIncrease);

                }  
            }
        }
        else {
            foreach (Building building in gm.buildingsPrefabs)
            {
                if(building.moneyIncrease != 0){
                    building.moneyIncrease = Mathf.RoundToInt(building.moneyIncrease * (1 + percent / 100.0f));
                }
            }
        }

        
    }

        public void increaseWood(int percent, string id = null){
        Debug.Log("ici");
        Debug.Log(gm.buildingsPrefabs.Count);
        if(id != null){
            foreach (Building building in gm.buildingsPrefabs)
            {
            
                if(id == building.id){
                    Debug.Log(building.woodIncrease);
                    building.woodIncrease = Mathf.RoundToInt(building.woodIncrease * (1 + percent / 100.0f));
                    Debug.Log(building.woodIncrease);

                }  
            }
        }
        else {
            foreach (Building building in gm.buildingsPrefabs)
            {
                if(building.woodIncrease != 0){
                    building.woodIncrease = Mathf.RoundToInt(building.woodIncrease * (1 + percent / 100.0f));
                   
                }
            }
        }


    }
    
}
