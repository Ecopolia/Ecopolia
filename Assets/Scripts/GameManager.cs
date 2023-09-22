using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public int money;
    public Text moneyDisplay;
    public int wood;
    public Text woodDisplay;
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

    public void LoadData(GameData data){
        this.money = data.money;
        this.wood = data.wood;
    }

    public void SaveData(ref GameData data){
        data.money = this.money;
        data.wood = this.wood;
    }
}
