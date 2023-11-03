using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class UI_Ressources_Overview_Controller : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager
    public Label overviewGatherDataPerHour1;
    public Label overviewGatherDataPerHour2;
    public Label overviewGatherDataPerHour3;

    public Label overviewBuilding1Label;
    public Button overviewSlot1Button;
    public Label overviewBuilding2Label;
    public Button overviewSlot2Button;
    public Label overviewBuilding3Label;
    public Button overviewSlot3Button;
    public Label overviewBuilding4Label;
    public Button overviewSlot4Button;

    public Button overviewCloseSlotInfoButton;

    public List<Label> overviewBuildingLabels = new List<Label>();
    public List<Button> overviewSlotButtons = new List<Button>();
    public bool isOpen;

    public bool isSlotInfoOpen;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        overviewGatherDataPerHour1 = root.Q<Label>("overview-ressource-gather-data-per-hour-1");
        overviewGatherDataPerHour2 = root.Q<Label>("overview-ressource-gather-data-per-hour-2");
        overviewGatherDataPerHour3 = root.Q<Label>("overview-ressource-gather-data-per-hour-3");

        overviewBuilding1Label = root.Q<Label>("overview-batiment-1-label");
        overviewSlot1Button = root.Q<Button>("overview-slot-1-button");
        overviewBuilding2Label = root.Q<Label>("overview-batiment-2-label");
        overviewSlot2Button = root.Q<Button>("overview-slot-2-button");
        overviewBuilding3Label = root.Q<Label>("overview-batiment-3-label");
        overviewSlot3Button = root.Q<Button>("overview-slot-3-button");
        overviewBuilding4Label = root.Q<Label>("overview-batiment-4-label");
        overviewSlot4Button = root.Q<Button>("overview-slot-4-button");
        overviewCloseSlotInfoButton = root.Q<Button>("overview-close-slot-info-button");

        overviewBuildingLabels.Add(overviewBuilding1Label);
        overviewBuildingLabels.Add(overviewBuilding2Label);
        overviewBuildingLabels.Add(overviewBuilding3Label);
        overviewBuildingLabels.Add(overviewBuilding4Label);

        overviewSlotButtons.Add(overviewSlot1Button);
        overviewSlotButtons.Add(overviewSlot2Button);
        overviewSlotButtons.Add(overviewSlot3Button);
        overviewSlotButtons.Add(overviewSlot4Button);

        // Set the initial opacity to 0 (closed by default)
        root.Q<VisualElement>("overview-container").style.opacity = 0.0f;
        overviewCloseSlotInfoButton.style.opacity = 0.0f;

        overviewGatherDataPerHour1.text = "0";
        overviewGatherDataPerHour2.text = "0";
        overviewGatherDataPerHour3.text = "0";

        overviewBuilding1Label.text = "";
        overviewBuilding2Label.text = "";
        overviewBuilding3Label.text = "";
        overviewBuilding4Label.text = "";

        isSlotInfoOpen = false;

        overviewSlot1Button.clicked += () => { StartCoroutine(DisplaySlotInfo(gameManager.stones[0])); };
        overviewCloseSlotInfoButton.clicked += () => { StartCoroutine(CloseSlotInfo()); };

        

    }

    void Update()
    {
        overviewGatherDataPerHour2.text = gameManager.GetMoneyRevenuePerHour().ToString() + " / h";
        overviewGatherDataPerHour1.text = gameManager.GetWoodRevenuePerHour().ToString() + " / h";
        
        if(!isSlotInfoOpen) {
            for ( int i = 0 ; i < gameManager.stones.Count ; i++) {
                if (gameManager.stones[i].isBuilt) 
                {
                    overviewBuildingLabels[i].text = gameManager.stones[i].build.buildingName+" | Or: "+gameManager.stones[i].build.moneyIncrease+" | Bois: "+gameManager.stones[i].build.woodIncrease;
                } else {
                    overviewBuildingLabels[i].text = "Empty | 0 | 0";
                }
            }
        }

    }


    public IEnumerator ToggleUI()
    {
        this.isOpen = !this.isOpen;

        var root = GetComponent<UIDocument>().rootVisualElement;

        if (this.isOpen)
        {
            // Open instantly display flex
            root.Q<VisualElement>("overview-container").style.opacity = 1.0f;
            root.Q<VisualElement>("overview-container").style.display = DisplayStyle.Flex;
            
        }
        else
        {
            // Close instantly
            root.Q<VisualElement>("overview-container").style.opacity = 0.0f;
            root.Q<VisualElement>("overview-container").style.display = DisplayStyle.None;
        }

        yield return null;
    }

    public IEnumerator DisplaySlotInfo(StoneScript stone) {
        isSlotInfoOpen = true;
        overviewCloseSlotInfoButton.style.opacity = 1.0f;
        Debug.Log("DisplaySlotInfo clicked");
        // clear text on all labels
        for ( int i = 0 ; i < overviewBuildingLabels.Count ; i++) {
            overviewBuildingLabels[i].text = "";
        }

        //display info on selected slot you can use all labels as new line for the text
        overviewBuilding1Label.text = stone.build.buildingName;
        overviewBuilding2Label.text = "Or: "+stone.build.moneyIncrease;
        overviewBuilding3Label.text = "Bois: "+stone.build.woodIncrease;
        overviewBuilding4Label.text = "Temps: "+stone.build.timeToBuild;

        yield return null;
    }

    public IEnumerator CloseSlotInfo() {
        isSlotInfoOpen = false;
        overviewCloseSlotInfoButton.style.opacity = 0.0f;
        Debug.Log("CloseSlotInfo clicked");
        // clear text on all labels
        for ( int i = 0 ; i < overviewBuildingLabels.Count ; i++) {
            overviewBuildingLabels[i].text = "";
        }

        yield return null;
    }

    
}
