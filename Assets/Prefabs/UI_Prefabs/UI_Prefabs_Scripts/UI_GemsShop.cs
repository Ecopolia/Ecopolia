using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GemsShop : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject[] appItems;
    private List<List<GameObject>> appItemsBatches;
    // Start is called before the first frame update
    void Start()
    {
        appItemsBatches = new List<List<GameObject>>();
        gameObject.SetActive(false);
        for (int i = 0; i < appItems.Length; i += 3)
        {
            List<GameObject> batch = new List<GameObject>();
            for (int j = i; j < Mathf.Min(i + 3, appItems.Length); j++)
            {
                batch.Add(appItems[j]);
            }
            appItemsBatches.Add(batch);
        }

        foreach (List<GameObject> batch in appItemsBatches)
        {
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
                batch[1].GetComponent<Button>().onClick.AddListener(() => gameManager.IncreaseResource('money', 100));
            }

            if (batch.Count > 2)
            {
                Transform child2 = batch[2].transform.Find("bg");
                if (child2 != null && child2.GetComponent<Button>() != null)
                {
                    child2.GetComponent<Button>().onClick.AddListener(() => OnButton2Click(batch));
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
