using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Canvas_TechTree : MonoBehaviour
{
    public GameManager gm;

    public GameObject[] Slots;

    public GameObject pipeLeft;
    public GameObject pipeRight;

    public Sprite gemsIcon;

    public Button CloseButton;

    private Sprite[] icons;

    public GameObject[] techSlots;

    public GameObject infoPopUpCanvas;

    private TechEngine techEngine;
    // Start is called before the first frame update
    void Start()
    {
        techEngine = gm.GetComponent<TechEngine>();
        for (int i = 0; i < techSlots.Length; i++)
        {
            int index = i;
            TMP_Text priceText = techSlots[index].transform.Find("pricePlank")?.GetComponentInChildren<TMP_Text>();
            TMP_Text namePanel = techSlots[index].transform.Find("namePanel")?.GetComponentInChildren<TMP_Text>();
            Button slotButton = techSlots[index].transform.Find("bg")?.GetComponent<Button>();
            Button popUpInfoButton = techSlots[index].transform.Find("InfoBubble")?.GetComponent<Button>();
            TMP_Text popUpTitle = infoPopUpCanvas.transform.Find("title")?.GetComponentInChildren<TMP_Text>();
            TMP_Text statsText = infoPopUpCanvas.transform.Find("stats")?.GetComponentInChildren<TMP_Text>();
            TMP_Text DescriptionText = infoPopUpCanvas.transform.Find("description")?.GetComponentInChildren<TMP_Text>();
            TMP_Text infoPriceText = infoPopUpCanvas.transform.Find("priceTag")?.GetComponentInChildren<TMP_Text>();

            Debug.Log(index);
            namePanel.text =  gm.technologies[index].Name;
            priceText.text = gm.technologies[index].CostGold + " " + gm.technologies[index].CostWood;


            slotButton.onClick.AddListener(() => {
                techEngine.BuyTech(index);
            });
            
            popUpInfoButton.onClick.AddListener(() => {
                
                popUpTitle.text = gm.technologies[index].Name;
                DescriptionText.text = gm.technologies[index].Description;
                infoPriceText.text = gm.technologies[index].CostGold + " " + gm.technologies[index].CostWood;
                statsText.text = gm.technologies[index].CostGold + " " + gm.technologies[index].CostWood;

                infoPopUpCanvas.SetActive(true);
            });

            
        }

        CloseButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsSlotInArray(GameObject slot, GameObject[] array)
    {
        foreach (GameObject item in array)
        {
            if (item == slot)
            {
                return true;
            }
        }
        return false;
    }

    void activatePipe(GameObject pipe)
    {
        foreach (Transform child in pipe.transform)
        {
            if (child.GetComponent<Image>() != null)
            {
                child.GetComponent<Image>().color = Color.green;
            }
        }
    }

    void activateSlot(GameObject slot)
    {
        foreach (Transform child in slot.transform)
        {
            if (child.GetComponent<Image>() != null)
            {
                if (child.GetComponent<Image>().name != "InfoBubble")
                {
                    child.GetComponent<Image>().color = Color.white;
                }
            }

            foreach (Transform child2 in child.transform)
            {
                if (child2.GetComponent<Image>() != null)
                {
                    // Check if the component name is not "InfoBubble" before graying
                    if (child2.GetComponent<Image>().name != "InfoBubble")
                    {
                        child2.GetComponent<Image>().color = Color.white;
                    }

                    // if(child2.GetComponent<Image>().name == "icon")
                    // {
                    //     child2.GetComponent<Image>().sprite = gemsIcon;
                    // }
                }
            }
        }
    }

    void desactivatePipe(GameObject pipe)
    {
        foreach (Transform child in pipe.transform)
        {
            if (child.GetComponent<Image>() != null)
            {
                child.GetComponent<Image>().color = Color.grey;
            }
        }
        
    }

    void desactivateSlot(GameObject slot)
    {
        // push the slot in the desactivatedSlots array
        foreach (Transform child in slot.transform)
        {
            if (child.GetComponent<Image>() != null)
            {
                if (child.GetComponent<Image>().name != "InfoBubble")
                {
                    child.GetComponent<Image>().color = Color.grey;
                }
            }

            foreach (Transform child2 in child.transform)
            {
                if (child2.GetComponent<Image>() != null)
                {
                    // Check if the component name is not "InfoBubble" before graying
                    if (child2.GetComponent<Image>().name != "InfoBubble")
                    {
                        child2.GetComponent<Image>().color = Color.grey;
                    }

                    // if(child2.GetComponent<Image>().name == "icon")
                    // {
                    //     child2.GetComponent<Image>().sprite = gemsIcon;
                    // }
                }
            }
        }
    }



    

    void TurnBgRed(GameObject slot)
    {
        Transform bg = slot.transform.Find("bg");
        if (bg != null && bg.GetComponent<Image>() != null)
        {
            bg.GetComponent<Image>().color = Color.red;
        }
    }

    void switchIcons(Sprite component) {

    }
}
