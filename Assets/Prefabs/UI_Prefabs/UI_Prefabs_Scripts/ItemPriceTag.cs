using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPriceTag : MonoBehaviour
{
    public GameManager gameManager;

    public Sprite green;
    public Sprite red;
    public Sprite brown;

    public Building[] building;

    public GameObject[] priceTags;

    // Start is called before the first frame update

    public Button CloseButton;

    public Button Slot1Button;
    void Start()
    {
        // this set active to false
        
        if (gameManager != null) {
            for (int i = 0; i < building.Length; i++) {
                if (building[i].moneyCost > gameManager.money ) {
                    priceTags[i].GetComponent<Image>().sprite = red;
                } else if (building[i].moneyCost < gameManager.money) {
                    priceTags[i].GetComponent<Image>().sprite = green;
                } else {
                    priceTags[i].GetComponent<Image>().sprite = brown;
                }


                priceTags[i].GetComponentInChildren<TMP_Text>().text = building[i].moneyCost.ToString();
            }


            CloseButton.onClick.AddListener(() => {
                gameObject.SetActive(false);
            });

            Slot1Button.onClick.AddListener(() => {
                gameManager.BuyBuilding(building[0]);
            });

            gameObject.SetActive(false);

            
        } else {
            // ignore
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
