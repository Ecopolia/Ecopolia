using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Canvas_Top : MonoBehaviour
{

    public GameManager gm;

    public Button MoreGoldButton;

    public Button MoreWoodButton;

    public Button MoreGemsButton;


    public TMP_Text GoldText;

    public TMP_Text WoodText;

    public TMP_Text GemsText;

    public Button AvatarOverviewButton;

    public GameObject RessourcesCanvasOverview;

    public GameObject TechTreeCanvas;
    public Button TechTreeButton;

    public GameObject GemsShopCanvas;

    public GameObject WeatherCanvas;

    public Button WeatherButton;


    // Start is called before the first frame update
    void Start()
    {
        if (gm != null){
            GoldText.text = gm.money.ToString();
            WoodText.text = gm.wood.ToString();
            GemsText.text = gm.gemme.ToString();

            MoreGoldButton.onClick.AddListener(() => {
                GemsShopCanvas.SetActive(true);
            });

            MoreWoodButton.onClick.AddListener(() => {
                GemsShopCanvas.SetActive(true);
            });

            MoreGemsButton.onClick.AddListener(() => {
                GemsShopCanvas.SetActive(true);
            });

            AvatarOverviewButton.onClick.AddListener(() => {
                RessourcesCanvasOverview.SetActive(true);
            });

            TechTreeButton.onClick.AddListener(() => {
                TechTreeCanvas.SetActive(true);
            });

            WeatherButton.onClick.AddListener(() => {
                WeatherCanvas.SetActive(true);
            });
            
        } else {
            // ignore
        }
        
    }

    // Update is called once per frame
    void Update()
    {
     if (gm != null) {
        GoldText.text = gm.money.ToString();
        WoodText.text = gm.wood.ToString();
        GemsText.text = gm.gemme.ToString();
     } else {
        // ignore
     }
    }
}
