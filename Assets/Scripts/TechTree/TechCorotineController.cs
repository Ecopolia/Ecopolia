using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechCorotineController : MonoBehaviour
{
    private int secondsRemaining;
    private float nextIncreaseTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        if(Time.time >= nextIncreaseTime){
            nextIncreaseTime = Time.time + secondsRemaining;

        }
        
    }
}
