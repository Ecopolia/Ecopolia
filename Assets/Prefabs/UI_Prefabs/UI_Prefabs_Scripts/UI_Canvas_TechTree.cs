using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Canvas_TechTree : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject[] Slots;

    public GameObject pipeLeft;
    public GameObject pipeRight;

    public Sprite gemsIcon;

    public Button CloseButton;

    private Sprite[] icons;

    private List<GameObject> desactivatedSlots;
    private List<List<GameObject>> slotBatches;


    // Start is called before the first frame update
    void Start()
    {
        desactivatedSlots = new List<GameObject>();
        // Loop through Slots and create a List of tuples of 3 slots
        slotBatches = new List<List<GameObject>>();
        for (int i = 0; i < Slots.Length; i += 3)
        {
            List<GameObject> batch = new List<GameObject>();
            for (int j = i; j < Mathf.Min(i + 3, Slots.Length); j++)
            {
                batch.Add(Slots[j]);
            }
            slotBatches.Add(batch);
        }


        // Loop through slot batches and set up the UI
        foreach (List<GameObject> batch in slotBatches)
        {
            // Deactivate the third slot in each batch
            desactivateSlot(batch[2]);

            // Set up button listeners for the first and second slots in each batch
            if (batch.Count > 0)
            {
                Transform child0 = batch[0].transform.Find("bg");
                if (child0 != null && child0.GetComponent<Button>() != null)
                {
                    child0.GetComponent<Button>().onClick.AddListener(() => OnButton0Click(batch));
                }
            }

            if (batch.Count > 1)
            {
                Transform child1 = batch[1].transform.Find("bg");
                if (child1 != null && child1.GetComponent<Button>() != null)
                {
                    child1.GetComponent<Button>().onClick.AddListener(() => OnButton1Click(batch));
                }
            }
        }

        CloseButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });

        gameObject.SetActive(false);
        
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
        desactivatedSlots.Add(slot);
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

    void OnButton0Click(List<GameObject> batch)
    {
        // Deactivate child1
        desactivateSlot(batch[1]);
        
        // Activate the third element of the current batch
        activateSlot(batch[2]);
        activatePipe(pipeLeft);
        // Deactivate the opposite pipe and turn bg image red of the opposite child (1, 0)
        desactivatePipe(pipeRight);
        TurnBgRed(batch[1]);

        // remove button 1 listener
        Transform child1 = batch[1].transform.Find("bg");
        if (child1 != null && child1.GetComponent<Button>() != null)
        {
            child1.GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    void OnButton1Click(List<GameObject> batch)
    {
        // Deactivate child0
        desactivateSlot(batch[0]);

        // Activate the third element of the current batch
        activateSlot(batch[2]);
        activatePipe(pipeRight);
        // Deactivate the opposite pipe and turn bg image red of the opposite child (0, 1)
        desactivatePipe(pipeLeft);
        TurnBgRed(batch[0]);

        // remove button 0 listener
        Transform child0 = batch[0].transform.Find("bg");
        if (child0 != null && child0.GetComponent<Button>() != null)
        {
            child0.GetComponent<Button>().onClick.RemoveAllListeners();
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
