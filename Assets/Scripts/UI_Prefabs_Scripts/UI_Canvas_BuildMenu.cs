using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Canvas_BuildMenu : MonoBehaviour
{
    public GameManager gm;

    public Sprite green;
    public Sprite red;
    public Sprite brown;

    public Building[] building;

    public GameObject[] priceTags;

    public GameObject[] ItemCount;

    

    public Button CloseButton;

    public Button Slot1Button;

    public Button Slot2Button;

    public Button Slot3Button;

    public Button Slot4Button;
    // Start is called before the first frame update
    void Start()
    {
        // this set active to false
        if (gm != null) {
            for (int i = 0; i < building.Length; i++) {
                if (building[i].moneyCost > gm.money ) {
                    priceTags[i].GetComponent<Image>().sprite = red;
                } else if (building[i].moneyCost < gm.money) {
                    priceTags[i].GetComponent<Image>().sprite = green;
                } else {
                    priceTags[i].GetComponent<Image>().sprite = brown;
                }


                priceTags[i].GetComponentInChildren<TMP_Text>().text = building[i].moneyCost.ToString();
            }

            for (int i = 0; i < ItemCount.Length; i++) {
                ItemCount[i].GetComponentInChildren<TMP_Text>().text = gm.getAllConstructByBuilding(building[i]).ToString();
            }


            CloseButton.onClick.AddListener(() => {
                gm.SetMenu(false);
                gameObject.SetActive(false);
            });

            Slot1Button.onClick.AddListener(() => {
                gm.BuyBuilding(building[0]);
            });

            Slot2Button.onClick.AddListener(() => {
                gm.BuyBuilding(building[1]);
            });

            Slot3Button.onClick.AddListener(() => {
                gm.BuyBuilding(building[2]);
            });

            Slot4Button.onClick.AddListener(() => {
                gm.BuyBuilding(building[3]);
            });

            gameObject.SetActive(false);
            
        } else {
            
            // ignore
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm != null) {
            for (int i = 0; i < ItemCount.Length; i++) {
                ItemCount[i].GetComponentInChildren<TMP_Text>().text = gm.getAllConstructByBuilding(building[i]).ToString();
            }
        } else {
            // ignore
        }
    }
}
