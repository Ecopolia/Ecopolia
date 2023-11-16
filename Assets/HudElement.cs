using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudElement : MonoBehaviour
{
    public TMP_Text MoneyText;
    public TMP_Text WoodText;
    public GameManager gameManager;

    public GameObject overviewCanvas;

    public Button avatarButton;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager != null)
        {
            MoneyText.text = gameManager.money.ToString();
            WoodText.text = gameManager.wood.ToString();
        }
        else
        {
            // ignore
        }

        avatarButton.onClick.AddListener(() => {
            overviewCanvas.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager != null)
        {
            MoneyText.text = gameManager.money.ToString();
            WoodText.text = gameManager.wood.ToString();
        }
        else
        {
           // ignore
        }
    }
}
