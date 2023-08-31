using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int money;
    public Text moneyDisplay;
    public int wood;
    public Text woodDisplay;
    // Start is called before the first frame update
    private Building buildingToPlace;
    // Update is called once per frame
    void Update()
    {
        moneyDisplay.text = money.ToString();
        woodDisplay.text = wood.ToString();
    }

    public void BuyBuilding(Building building)
    {
        if(money >= building.cost){
            money -= building.cost;
            buildingToPlace = building;
            StoneScript.selectedStone.ConstructBuilding(building);
        }
    }
}
