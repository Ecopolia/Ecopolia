using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ui_canva_overview : MonoBehaviour
{
     public GameManager gm;

     public TMP_Text Slot1Text;
     public TMP_Text Slot2Text;

     public Button CloseButton;
    // Start is called before the first frame update
    void Start()
    {
        
        if (gm != null)
        {
            Slot1Text.text = gm.GetMoneyRevenuePerHour().ToString() + " / h";
            Slot2Text.text = gm.GetWoodRevenuePerHour().ToString() + " / h";
        }
        else
        {
            // ignore
        }

        CloseButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (gm != null)
        {
            Slot1Text.text = gm.GetMoneyRevenuePerHour().ToString() + " / h";
            Slot2Text.text = gm.GetWoodRevenuePerHour().ToString() + " / h";
        }
        else
        {
            // ignore
        }
        
    }
}
