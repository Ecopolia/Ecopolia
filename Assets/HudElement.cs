using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudElement : MonoBehaviour
{
    public TMP_Text MoneyText;
    public TMP_Text WoodText;
    public GameManager gm;

    public GameObject overviewCanvas;

    public Button avatarButton;

    // Start is called before the first frame update
    void Start()
    {
        if (gm != null)
        {
            MoneyText.text = gm.money.ToString();
            WoodText.text = gm.wood.ToString();
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
        if (gm != null)
        {
            MoneyText.text = gm.money.ToString();
            WoodText.text = gm.wood.ToString();
        }
        else
        {
           // ignore
        }
    }
}
