using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Canvas_BuildMenu : MonoBehaviour
{
    public GameManager gameManager;

    public Sprite green;
    public Sprite red;
    public Sprite brown;

    public Building[] building;

    public GameObject[] priceTags;

    public GameObject[] ItemCount;

    // Start is called before the first frame update

    public Button CloseButton;

    public Button Slot1Button;

    public Button Slot2Button;

    public Button Slot3Button;

    public Button Slot4Button;
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

            for (int i = 0; i < ItemCount.Length; i++) {
                ItemCount[i].GetComponentInChildren<TMP_Text>().text = gameManager.getAllConstructByBuilding(building[i]).ToString();
            }


            CloseButton.onClick.AddListener(() => {
                gameObject.SetActive(false);
            });

            Slot1Button.onClick.AddListener(() => {
                gameManager.BuyBuilding(building[0]);
            });

            Slot2Button.onClick.AddListener(() => {
                gameManager.BuyBuilding(building[1]);
            });

            Slot3Button.onClick.AddListener(() => {
                gameManager.BuyBuilding(building[2]);
            });

            Slot4Button.onClick.AddListener(() => {
                gameManager.BuyBuilding(building[3]);
            });

            gameObject.SetActive(false);

            
        } else {
            // ignore
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager != null) {
            for (int i = 0; i < ItemCount.Length; i++) {
                ItemCount[i].GetComponentInChildren<TMP_Text>().text = gameManager.getAllConstructByBuilding(building[i]).ToString();
            }
        } else {
            // ignore
        }
    }
}
