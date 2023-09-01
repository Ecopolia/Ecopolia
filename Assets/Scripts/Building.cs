using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public int cost;
    public int moneyIncrease;
    public int woodIncrease;

    public float timeBtwIncrease;
    private float nextIncreaseTime;
    private GameManager gm;
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
    }
}
