using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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


    public void BuyTech(int id, GameObject loadingBar){
        gm = FindObjectOfType<GameManager>();

        var specificTech = gm.technologies.Find((x) => x.ID == id);
        if (specificTech != null && specificTech.State == "Locked")
        {
            Debug.Log("Buying technology: " + specificTech.Name);
            int requiredGold = specificTech.CostGold;
            int requiredWood = specificTech.CostWood;

            if (gm.HasEnoughResources(requiredGold, requiredWood) && specificTech.State =="Locked")
            {
                // Déduisez le coût des ressources en utilisant GameManager
                gm.DeductResources(requiredGold, requiredWood);

                specificTech.State = "Upgrading";
                StartCoroutine(displayLoadingBar(specificTech, loadingBar));
                StartCoroutine(CompletePurchaseWithDelay(specificTech, loadingBar));

            }
            else
            {
                Debug.Log("Insufficient resources to buy this technology.");
            }
        } else if (specificTech != null && specificTech.State == "Upgrading")
        {
            // SkipWithGems();
        }
        else
        {
            Debug.Log("Technology is already unlocked or not available.");
        }

    }
    private IEnumerator<WaitForSeconds> CompletePurchaseWithDelay(Technology specificTech, GameObject loadingBar)
    {
        //var technologyButton = gameObject.GetComponent<Button>();
        int secondsRemaining = specificTech.ResearchTime;
        TMP_Text loadingBarTimerText = loadingBar.transform.Find("timer_text")?.GetComponentInChildren<TMP_Text>();
        while (secondsRemaining > 0)
        {
            //technologyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Recherche en cours... (" + secondsRemaining + "s)\n Cliquez pour passer avec "+secondsRemaining/5+" gemmes";
            loadingBarTimerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", secondsRemaining / 3600, (secondsRemaining / 60) % 60, secondsRemaining % 60);

            yield return new WaitForSeconds(1f);
            secondsRemaining--;
        }



        unlockTech(specificTech);
        Debug.Log("Coroutine benefit used");
    }

    private IEnumerator<WaitForSeconds> displayLoadingBar(Technology specificTech, GameObject loadingBar)
    {
        while(specificTech.State == "Upgrading")
        {
            loadingBar.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
        loadingBar.SetActive(false);
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

    public void unlockTech(Technology specificTech){
        increaseMoney(specificTech.GoldBenefits);
        increaseWood(specificTech.WoodBenefits);
        specificTech.State = "Unlocked";
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
