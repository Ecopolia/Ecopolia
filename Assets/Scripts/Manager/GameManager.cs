
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
    public int pollution;
    public List<Building> buildings = new List<Building>();
    public List<Building> buildingsPrefabs = new List<Building>();
    public List<StoneScript> stones = new List<StoneScript>();
    public bool menuActive = false;
    public Building chantier;
    public List<Technology> technologies = new List<Technology>();

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
        if (HasEnoughResources(building.moneyCost, building.woodCost)) {
            DeductResources(building.moneyCost, building.woodCost);
            
            ConstructBuilding(building, StoneScript.selectedStone, null);
        } else {
            // mettre message alert nomoney
            Debug.Log("no money or wood");
            StoneScript.selectedStone.SetBuild(null, 0);
        }

    }

    // Permet d'ameliorer un batiment avec comme paramètre le nouveau batiment et le batiment à améliorer
    public bool UpBuilding(Building buildingUp, Building buildingToReplace){
        if (HasEnoughResources(buildingUp.moneyCost, buildingUp.woodCost)) {
            DeductResources(buildingUp.moneyCost, buildingUp.woodCost);
            
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
            stone.SetBuild(buildingToPlace, timeLeft);
        }

        if(buildingToUp){
            buildings.Remove(stone.build);
            buildings.Add(buildingToPlace);
            
            Instantiate(buildingToPlace, buildingToUp.transform.position, Quaternion.identity);
            buildingToUp.gameObject.SetActive(false);
            stone.build = buildingToPlace;

            // foreach (var building in buildings)
            // {
            //     Debug.Log(building);
            //     if(buildingToUp == building){
            //         Debug.Log("oui");
            //     }
            // }
        }

        buildingToPlace.stone = stone;
        actuPollution();
        
    }

    public void actuPollution(){
        this.pollution = 0;
        foreach (var building in buildings){
            this.pollution += building.pollution;
        }

    }

    // Permet de dire si le menu est open ou fermé au Stone avec comme paramètre un booléen true/false pour open/close
    public void SetMenu(bool menu){
        menuActive = menu;
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

    // Methode qui renvoie le nombre de buildingX construit
    public int getAllConstructByBuilding(Building building) {
        var nbBuilding = 0;
        foreach (var item in buildings)
        {
            if(building.id == item.id) {
                nbBuilding ++;
            }
        }

        return nbBuilding;
    }
    
    // Fonction pour augmenter la ressource spécifiée et returns void
    // Paramètres :
    //   - resourceType : Le type de ressource à augmenter (money, wood, gemme).
    //   - increaseValue : La valeur à ajouter à la ressource.
    public void IncreaseResource(string resourceType, int increaseValue)
    {
        switch (resourceType.ToLower())
        {
            case "money":
                money += increaseValue;
                break;
            case "wood":
                wood += increaseValue;
                break;
            case "gemme":
                gemme += increaseValue;
                break;
            default:
                Debug.LogError("Resource type not recognized: " + resourceType);
                break;
        }
    }
    
    

    // Load la data de la save
    public void LoadData(GameData data){
        this.money = data.money;
        this.wood = data.wood;
        this.gemme = data.gemme;
        this.pollution = data.pollution;
    }

    // Save la data dans la save
    public void SaveData(ref GameData data){
        data.money = this.money;
        data.wood = this.wood;
        data.gemme = this.gemme;
        data.pollution = this.pollution;
    }

}
