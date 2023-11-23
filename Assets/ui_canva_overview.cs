using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ui_canva_overview : MonoBehaviour
{
     public GameManager gameManager;

     public TMP_Text Slot1Text;
     public TMP_Text Slot2Text;

     public Button CloseButton;
    // Start is called before the first frame update
    void Start()
    {
        
        if (gameManager != null)
        {
            Slot1Text.text = gameManager.GetMoneyRevenuePerHour().ToString() + " / h";
            Slot2Text.text = gameManager.GetWoodRevenuePerHour().ToString() + " / h";
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

        if (gameManager != null)
        {
            Slot1Text.text = gameManager.GetMoneyRevenuePerHour().ToString() + " / h";
            Slot2Text.text = gameManager.GetWoodRevenuePerHour().ToString() + " / h";
        }
        else
        {
            // ignore
        }
        
    }
}
