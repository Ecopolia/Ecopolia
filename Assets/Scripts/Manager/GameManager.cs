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
    public List<Building> buildingsPrefabs = new List<Building>();

    // Update is called once per frame
    void Update()
    {
        moneyDisplay.text = money.ToString();
        woodDisplay.text = wood.ToString();    
    }

    public void BuyBuilding(Building building)
    {
        
        if(building.moneyCost != 0 && building.woodCost != 0) {
            if(money >= building.moneyCost && wood >= building.woodCost){
                money -= building.moneyCost;
                wood -= building.woodCost;
                buildings.Add(building);
                ConstructBuilding(building, StoneScript.selectedStone, null);
            } else {
                StoneScript.selectedStone.SetBuild(null);
            }

        } else if (building.moneyCost != 0) {
            if(money >= building.moneyCost) {

                money -= building.moneyCost;
                buildings.Add(building);
                ConstructBuilding(building, StoneScript.selectedStone, null);
            } else {
                StoneScript.selectedStone.SetBuild(null);
            }

        } else if (building.woodCost != 0) {
            if(wood >= building.woodCost) {
                wood -= building.woodCost;
                buildings.Add(building);
                ConstructBuilding(building, StoneScript.selectedStone, null);
            } else {
                StoneScript.selectedStone.SetBuild(null);
            }

        } else {
            buildings.Add(building);
            ConstructBuilding(building, StoneScript.selectedStone, null);
        }

    }

    public void ConstructBuilding(Building buildingToPlace, StoneScript stone, Building buildingToUp = null)
    {
        if(stone && !buildingToUp){
            Instantiate(buildingToPlace, stone.transform.position, Quaternion.identity);
            stone.gameObject.SetActive(false);
            stone.SetBuild(buildingToPlace);
        }

        if(buildingToUp){
            Instantiate(buildingToPlace, buildingToUp.transform.position, Quaternion.identity);
            buildingToUp.gameObject.SetActive(false);
        }

        buildingToPlace.stone = stone;

        
    }

    public void SetMenu(bool menu){
        StoneScript[] stoneScripts = FindObjectsOfType<StoneScript>();

        foreach (StoneScript stoneScript in stoneScripts)
        {
            stoneScript.isMenu = menu;
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
