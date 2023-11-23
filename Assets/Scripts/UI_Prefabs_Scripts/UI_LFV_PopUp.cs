using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_LFV_PopUp : MonoBehaviour
{
    public Button acceptButton;
    public Button declineButton;

    public TMP_Text titleText;
    // Start is called before the first frame update
    void Start()
    {
        
        acceptButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });

        declineButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });

        titleText.text = "LFV";

        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
