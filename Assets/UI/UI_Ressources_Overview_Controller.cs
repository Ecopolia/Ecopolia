using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_Ressources_Overview_Controller : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager
    public Label overviewGatherDataPerHour1;
    public Label overviewGatherDataPerHour2;
    public Label overviewGatherDataPerHour3;

    public Button overviewUiDisplayButton;

    public bool isOpen;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        overviewUiDisplayButton = root.Q<Button>("overview-ui-display-button");
        overviewGatherDataPerHour1 = root.Q<Label>("overview-ressource-gather-data-per-hour-1");
        overviewGatherDataPerHour2 = root.Q<Label>("overview-ressource-gather-data-per-hour-2");
        overviewGatherDataPerHour3 = root.Q<Label>("overview-ressource-gather-data-per-hour-3");

        // Set the initial opacity to 0 (closed by default)
        root.Q<VisualElement>("overview-container").style.opacity = 0.0f;

        overviewGatherDataPerHour1.text = "0";
        overviewGatherDataPerHour2.text = "0";
        overviewGatherDataPerHour3.text = "0";

        overviewUiDisplayButton.clicked += OnOverviewUiDisplayButtonClick;
    }

    void Update()
    {
        overviewGatherDataPerHour2.text = gameManager.GetMoneyRevenuePerHour().ToString() + " / h";
        overviewGatherDataPerHour1.text = gameManager.GetWoodRevenuePerHour().ToString() + " / h";

    }

    public void OnOverviewUiDisplayButtonClick()
    {
        StartCoroutine(ToggleUI());
    }

    private IEnumerator ToggleUI()
    {
        this.isOpen = !this.isOpen;

        var root = GetComponent<UIDocument>().rootVisualElement;

        if (this.isOpen)
        {
            // Open instantly
            root.Q<VisualElement>("overview-container").style.opacity = 1.0f;
        }
        else
        {
            // Close instantly
            root.Q<VisualElement>("overview-container").style.opacity = 0.0f;
        }

        yield return null; // Ensure that the Coroutine exits immediately
    }
}

