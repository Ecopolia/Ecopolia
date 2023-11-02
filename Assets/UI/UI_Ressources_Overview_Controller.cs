using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

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

    public bool isOpen;

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

        // Set the initial opacity to 0 (closed by default)
        root.Q<VisualElement>("overview-container").style.opacity = 0.0f;

        overviewGatherDataPerHour1.text = "0";
        overviewGatherDataPerHour2.text = "0";
        overviewGatherDataPerHour3.text = "0";

        overviewBuilding1Label.text = "Empty | 0";
        overviewBuilding2Label.text = "Empty | 0";
        overviewBuilding3Label.text = "Empty | 0";
        overviewBuilding4Label.text = "Empty | 0";

        overviewSlot1Button.clicked += () => {
            Debug.Log(gameManager.stones[0].isBuilt);
        };
        overviewSlot2Button.clicked += () => {
            Debug.Log(gameManager.stones[1].isBuilt);
        };
        overviewSlot3Button.clicked += () => {
            Debug.Log(gameManager.stones[2].isBuilt);
        };
        overviewSlot4Button.clicked += () => {
            Debug.Log(gameManager.stones[3].isBuilt);
        };

    }

    void Update()
    {
        overviewGatherDataPerHour2.text = gameManager.GetMoneyRevenuePerHour().ToString() + " / h";
        overviewGatherDataPerHour1.text = gameManager.GetWoodRevenuePerHour().ToString() + " / h";

        foreach(Building building in gameManager.buildings) {
            if (overviewBuilding1Label.text == "Empty | 0")
            {
                overviewBuilding1Label.text = building.buildingName + " | Or: " + building.moneyCost + " | Bois: " + building.woodCost;
            }
            else if (overviewBuilding2Label.text == "Empty | 0")
            {
                overviewBuilding2Label.text = building.buildingName + " | Or: " + building.moneyCost + " | Bois: " + building.woodCost;
            }
            else if (overviewBuilding3Label.text == "Empty | 0")
            {
                overviewBuilding3Label.text = building.buildingName + " | Or: " + building.moneyCost + " | Bois: " + building.woodCost;
            } 
            else {
                overviewBuilding4Label.text = building.buildingName + " | Or: " + building.moneyCost + " | Bois: " + building.woodCost;
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

    
}
