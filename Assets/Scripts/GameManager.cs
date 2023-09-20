using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public int money;
    public Text moneyDisplay;
    public int wood;
    public Text woodDisplay;
    // Start is called before the first frame update
    private Building buildingToPlace;
    public List<Building> buildings = new List<Building>();
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
            buildings.Add(building);
            StoneScript.selectedStone.ConstructBuilding(building);
        }
    }

    public float GetMoneyRevenuePerHour()
    {
        float sum = 0;
        foreach(Building building in buildings)
        {
            sum += building.CalculateMoneyRevenuePerHour();
        }
        return sum;
    }

    public float GetWoodRevenuePerHour()
    {
        float sum = 0;
        foreach(Building building in buildings)
        {
            sum += building.CalculateWoodRevenuePerHour();
        }
        return sum;
    }
}
