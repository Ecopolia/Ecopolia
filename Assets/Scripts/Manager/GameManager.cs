using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public int money;
    public int wood;
    public int gemme;
    public List<Building> buildings = new List<Building>();
    public List<Building> buildingsPrefabs = new List<Building>();
    public List<StoneScript> stones = new List<StoneScript>();

    public Building chantier;

    // Start is called before the first frame update
    void Start(){
        stones.AddRange(FindObjectsOfType<StoneScript>(true));
    }
    // Update is called once per frame
    void Update()
    {

    }

    // Permet d'acheter un batiment avec comme paramètre le batiment 
    public void BuyBuilding(Building building)
    {
        if ((building.moneyCost == 0 || money >= building.moneyCost) && (building.woodCost == 0 || wood >= building.woodCost)) {
            if (building.moneyCost > 0) money -= building.moneyCost;
            if (building.woodCost > 0) wood -= building.woodCost;
            
            ConstructBuilding(building, StoneScript.selectedStone, null);
        } else {
            // mettre message alert nomoney
            Debug.Log("no money or wood");
            StoneScript.selectedStone.SetBuild(null);
        }

    }

    // Permet d'ameliorer un batiment avec comme paramètre le nouveau batiment et le batiment à améliorer
    public bool UpBuilding(Building buildingUp, Building buildingToReplace){
        if ((buildingUp.moneyCost == 0 || money >= buildingUp.moneyCost) && (buildingUp.woodCost == 0 || wood >= buildingUp.woodCost)) {
            if (buildingUp.moneyCost > 0) money -= buildingUp.moneyCost;
            if (buildingUp.woodCost > 0) wood -= buildingUp.woodCost;
            
            ConstructBuilding(buildingUp, buildingToReplace.stone, buildingToReplace);
            return true;
        } else {
            // mettre message alert nomoney
            Debug.Log("no money or wood");
            return false;
        }
    }

    // Permet de construire le batiment avec comme paramètre le batiment à placer, la stone pour l'emplacement, 
    // si il y a déjà un batiment alors on rajoute le batiment en question, et si le batiment était en construction lors de la save on rajoute le temps restant
    public void ConstructBuilding(Building buildingToPlace, StoneScript stone, Building buildingToUp = null, float timeLeft = -1)
    {
        if(stone && !buildingToUp){
            chantier.buildingToPlace = buildingToPlace;
            chantier.stone = stone;

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
            buildings.Remove(stone.build);
            buildings.Add(buildingToPlace);
            
            Instantiate(buildingToPlace, buildingToUp.transform.position, Quaternion.identity);
            buildingToUp.gameObject.SetActive(false);
            stone.build = buildingToPlace;

            foreach (var building in buildings)
            {
                Debug.Log(building);
                if(buildingToUp == building){
                    Debug.Log("oui");
                }
            }
        }

        buildingToPlace.stone = stone;
        
        
    }

    // Permet de dire si le menu est open ou fermé au Stone avec comme paramètre un booléen true/false pour open/close
    public void SetMenu(bool menu){
        StoneScript[] stoneScripts = FindObjectsOfType<StoneScript>();

        foreach (StoneScript stoneScript in stoneScripts)
        {
            stoneScript.isMenu = menu;
        }
    }

    // Renvoie la money par heure
    public float GetMoneyRevenuePerHour()
    {
        float sum = 0;
        foreach(Building building in buildings)
        {
            sum += building.CalculateMoneyRevenuePerHour();
        }
        return sum;
    }

    // Renvoie le wood par heure
    public float GetWoodRevenuePerHour()
    {
        float sum = 0;
        foreach(Building building in buildings)
        {
            sum += building.CalculateWoodRevenuePerHour();
        }
        return sum;
    }

    // Load la data de la save
    public void LoadData(GameData data){
        this.money = data.money;
        this.wood = data.wood;
    }

    // Save la data dans la save
    public void SaveData(ref GameData data){
        data.money = this.money;
        data.wood = this.wood;
    }

     // Méthode pour vérifier si le joueur a suffisamment de ressources
    public bool HasEnoughResources(int requiredGold, int requiredWood)
    {
        return money >= requiredGold && wood >= requiredWood;
    }

    // Méthode pour déduire les ressources
    public void DeductResources(int requiredGold, int requiredWood)
    {
        if (HasEnoughResources(requiredGold, requiredWood))
        {
            money -= requiredGold;
            wood -= requiredWood;
        }
    }
}
