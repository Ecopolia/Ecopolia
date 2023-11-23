using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements; // Add this line


public class UI_Top_Controller : MonoBehaviour
{
    public VisualElement leafIcon;
    public Label leafScore;
    public Label woodText;
    public Label moneyText;
    public Button UiRessourcesOverviewButton;
    public UI_Ressources_Overview_Controller UIRessourcesOverviewController;
    public GameManager gm;

    public string score = "E";
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        leafIcon = root.Q<VisualElement>("ui-top-leaf-ecoscore-icon");
        leafScore = root.Q<Label>("ui-top-leaf-ecoscore-label");
        UiRessourcesOverviewButton = root.Q<Button>("ui-top-ressource-overview-display");
        woodText = root.Q<Label>("ui-top-ressource-wood-label");
        moneyText = root.Q<Label>("ui-top-ressource-money-label");
        
        UiRessourcesOverviewButton.clicked += onUiRessourcesOverviewButtonClick;
       
    }

    // Update is called once per frame
    void Update()
    {
        leafIcon.style.unityBackgroundImageTintColor = Colorleaf(score);
        leafScore.text = score;
        if (Colorleaf(score) == new Color(0.5f, 0.5f, 0.5f, 1)) 
        {
            leafScore.text = "?";
        } else {
            leafScore.text = score;
        }
        woodText.text = gm.wood.ToString();
        moneyText.text = gm.money.ToString();
    }
    Color Colorleaf(string score){
        switch (score)
        {
            case "A":
                // #1E8F4E
                return new Color(0.1176471f, 0.5607843f, 0.3058824f, 1);
            case "B":
                // #2ECC71
                return new Color(0.1803922f, 0.8f, 0.4431373f, 1);
            case "C":
                // #F5C100
                return new Color(0.9607843f, 0.7568628f, 0, 1);
            case "D":
             // #EF7E1A
                return new Color(0.9372549f, 0.4941176f, 0.1019608f, 1);
            case "E":
                // #D93726
                return new Color(0.8509804f, 0.2156863f, 0.1490196f, 1);
            case "F":
                //black
                return new Color(0, 0, 0, 1);
            
            default:
                // grey 
                return new Color(0.5f, 0.5f, 0.5f, 1);
        }
    }

    void onUiRessourcesOverviewButtonClick()
    {
        StartCoroutine(UIRessourcesOverviewController.ToggleUI());
    }

}
