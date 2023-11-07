using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] public string id;

    [ContextMenu("Generate unique id")]
    private void GenerateId(){
        id = System.Guid.NewGuid().ToString();
    }
    public int moneyCost;
    public int woodCost;
    public int moneyIncrease;
    public int woodIncrease;
    public float timeBtwIncrease;
    private float nextIncreaseTime;
    private GameManager gm;
    public StoneScript stone;
    public Building buildingToPlace = null;
    public float timeToBuild;
    public float timeBuild = 0;
    public float timeLeft = 0;
    public string buildingName;
    public string description;
    private bool buttonActive = false;
    public ButtonUp buttonObject;
    private ButtonUp buttonUpActive;
    public Building buildingUp;

    // Quand un clique sur l'objet est réaliser déclenche la fonction
    // Fait apparaitre le bouton d'amélioration si le batiment à une amélioration possible
    private void OnMouseDown()
    {
        if(buildingUp){
            if (buttonActive)
            {
                Destroy(buttonUpActive.gameObject);
                buttonUpActive = null;
                buttonActive = false;
                GetComponent<Collider>().isTrigger = true;
            }
            else
            {
                buttonUpActive = Instantiate(buttonObject, new Vector3(transform.position.x, transform.position.y-1, 50f), Quaternion.identity);
                buttonUpActive.gameObject.SetActive(true);
                buttonUpActive.buildingUp = buildingUp;
                buttonUpActive.buildingToReplace = this;
                buttonActive = true;
                GetComponent<Collider>().isTrigger = false;
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextIncreaseTime){
            nextIncreaseTime = Time.time + timeBtwIncrease;
            gm.money += moneyIncrease;
            gm.wood += woodIncrease;
        }


        if(buildingToPlace != null){
            if(Time.time >= timeBuild){
                gm.ConstructBuilding(buildingToPlace, this.stone, this);
            } else {
                timeLeft = timeBuild - Time.time;
            }
        }
    }

    // Calcule et renvoie la money par heure
    public float CalculateMoneyRevenuePerHour()
    {
        return moneyIncrease * (3600 / timeBtwIncrease);
    }

    // Calcule et renvoie le bois par heure
    public float CalculateWoodRevenuePerHour()
    {
        return woodIncrease * (3600 / timeBtwIncrease);
    }

}
