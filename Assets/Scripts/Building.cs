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
    private bool buttonActive = false;
    public ButtonUp buttonObject;
    public Building buildingUp;

    private void OnMouseDown()
    {
        if (buttonActive)
        {
            buttonObject.transform.position = new Vector3(transform.position.x, transform.position.y, 50f);
            buttonObject.gameObject.SetActive(false);
            buttonObject.buildingUp = null;
            buttonObject.buildingToReplace = null;
            buttonActive = false;
        }
        else
        {
            buttonObject.transform.position = new Vector3(50f, 50f, 50f);
            buttonObject.gameObject.SetActive(true);
            buttonObject.buildingUp = buildingUp;
            buttonObject.buildingToReplace = this;
            buttonActive = true;
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
                gm.ConstructBuilding(buildingToPlace, null, this);
            } else {
                timeLeft = timeBuild - Time.time;
            }
        }
    }

    public float CalculateMoneyRevenuePerHour()
    {
        return moneyIncrease * (3600 / timeBtwIncrease);
    }

    public float CalculateWoodRevenuePerHour()
    {
        return woodIncrease * (3600 / timeBtwIncrease);
    }

}
