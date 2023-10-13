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

    public Building chantier;

    // Update is called once per frame
    void Update()
    {
        moneyDisplay.text = money.ToString();
        woodDisplay.text = wood.ToString();    
    }

    public void BuyBuilding(Building building)
    {
        
        if ((building.moneyCost == 0 || money >= building.moneyCost) && (building.woodCost == 0 || wood >= building.woodCost)) {
            if (building.moneyCost > 0) money -= building.moneyCost;
            if (building.woodCost > 0) wood -= building.woodCost;
            
            ConstructBuilding(building, StoneScript.selectedStone, null);
        } else {
            StoneScript.selectedStone.SetBuild(null);
        }

    }

    public void ConstructBuilding(Building buildingToPlace, StoneScript stone, Building buildingToUp = null, float timeLeft = -1)
    {
        if(stone && !buildingToUp){
            chantier.buildingToPlace = buildingToPlace;
            if(timeLeft == 0){
                chantier.timeBuild = 0;
            } else if(timeLeft != -1) {
                chantier.timeBuild = Time.time + buildingToPlace.timeToBuild - timeLeft;
            } else {
                chantier.timeBuild = Time.time + buildingToPlace.timeToBuild;
            }

            
            Instantiate(chantier, stone.transform.position, Quaternion.identity);
            stone.gameObject.SetActive(false);
            stone.SetBuild(buildingToPlace);
        }

        if(buildingToUp){
            buildings.Add(buildingToPlace);
            buildings.Remove(buildingToUp);
            Instantiate(buildingToPlace, buildingToUp.transform.position, Quaternion.identity);
            buildingToUp.gameObject.SetActive(false);
            buildingToUp.stone.build = buildingToPlace;
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
