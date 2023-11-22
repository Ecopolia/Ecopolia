using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GemsShop : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject[] appItems;

    public Button closeButton;
    private List<List<GameObject>> appItemsBatches;
    // Start is called before the first frame update
    void Start()
    {
        appItemsBatches = new List<List<GameObject>>();
        string[] resourceTypes = { "money", "wood", "gemme" };
        int[] values = { 100, 1000, 10000 };

        for (int i = 0; i < appItems.Length; i += 3)
        {
            List<GameObject> batch = new List<GameObject>();
            for (int j = i; j < Mathf.Min(i + 3, appItems.Length); j++)
            {
                batch.Add(appItems[j]);
            }
            appItemsBatches.Add(batch);
        }

        for (int i = 0; i < appItemsBatches.Count; i++)
        {
            List<GameObject> batch = appItemsBatches[i];

            for (int j = 0; j < batch.Count; j++)
            {
                GameObject item = batch[j];
                Button button = item.GetComponent<Button>();

                int currentIndex = i;
                int currentJndex = j;

                // Add the listener
                button.onClick.AddListener(() => {
                    if (currentIndex >= 0 && currentIndex < resourceTypes.Length &&
                        currentJndex >= 0 && currentJndex < values.Length)
                    {
                        gameManager.IncreaseResource(resourceTypes[currentIndex], values[currentJndex]);
                    }
                    else
                    {
                        Debug.Log("Not implemented");
                    }
                });
            }
        }

        closeButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });

        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
