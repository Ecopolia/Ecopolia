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

    // Start is called before the first frame update
    void Start()
    {
    
        foreach (Transform child in Slots[2].transform)
        {
            if (child.GetComponent<Image>() != null)
            {
                // Check if the component name is not "InfoBubble" before graying
                if (child.GetComponent<Image>().name != "InfoBubble")
                {
                    child.GetComponent<Image>().color = Color.grey;
                }
            }

            // level 2 childs
            foreach (Transform child2 in child.transform)
            {
                if (child2.GetComponent<Image>() != null)
                {
                    // Check if the component name is not "InfoBubble" before graying
                    if (child2.GetComponent<Image>().name != "InfoBubble")
                    {
                        child2.GetComponent<Image>().color = Color.grey;
                    }
                }
            }
        }

        // loop through pipes children find image and set color to grey
        foreach (Transform child in pipeLeft.transform)
        {
            if (child.GetComponent<Image>() != null)
            {
                child.GetComponent<Image>().color = Color.grey;
            }
        }

        foreach (Transform child in pipeRight.transform)
        {
            if (child.GetComponent<Image>() != null)
            {
                child.GetComponent<Image>().color = Color.grey;
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
