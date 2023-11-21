using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Canvas_Top : MonoBehaviour
{

    public GameManager gameManager;

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


    // Start is called before the first frame update
    void Start()
    {
        if (gameManager != null){
            GoldText.text = gameManager.money.ToString();
            WoodText.text = gameManager.wood.ToString();
            GemsText.text = gameManager.gemme.ToString();

            MoreGoldButton.onClick.AddListener(() => {
                gameManager.money += 100;
            });

            MoreWoodButton.onClick.AddListener(() => {
                gameManager.wood += 100;
            });

            MoreGemsButton.onClick.AddListener(() => {
                gameManager.gemme += 100;
            });

            AvatarOverviewButton.onClick.AddListener(() => {
                RessourcesCanvasOverview.SetActive(true);
            });

            TechTreeButton.onClick.AddListener(() => {
                TechTreeCanvas.SetActive(true);
            });
            
        } else {
            // ignore
        }
        
    }

    // Update is called once per frame
    void Update()
    {
     if (gameManager != null) {
        GoldText.text = gameManager.money.ToString();
        WoodText.text = gameManager.wood.ToString();
        GemsText.text = gameManager.gemme.ToString();
     } else {
        // ignore
     }
    }
}
