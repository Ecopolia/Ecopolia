using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_BuildMenu_Conroller : MonoBehaviour
{
    public Button closeButton;
    public Button OpenButton;
    public Label buildMenuTitle;
    public Button building1;
    private bool isOpen;
    public Building[] buildingPrefab; // Make sure to replace 'Building' with the actual class name of your prefab.

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Build Menu Controller started");
        var root = GetComponent<UIDocument>().rootVisualElement;
        closeButton = root.Q<Button>("buildmenu-shop-close");
        buildMenuTitle = root.Q<Label>("buildmenu-shop-title");
        building1 = root.Q<Button>("buildmenu-shop-building-card-1");

        // Make sure buildingPrefab array has the prefab assigned.
        if (buildingPrefab.Length > 0)
        {
            // Access the SpriteRenderer of the prefab.
            SpriteRenderer prefabRenderer = buildingPrefab[0].GetComponent<SpriteRenderer>();

            if (prefabRenderer != null)
            {
                // Get the sprite from the SpriteRenderer.
                Sprite buildingSprite = prefabRenderer.sprite;

                // Create a Texture2D from the sprite's texture.
                Texture2D buildingTexture = buildingSprite.texture;

                // Set the Button's background image to the Texture2D.
                building1.style.backgroundImage = new StyleBackground(buildingTexture);
            }
            else
            {
                Debug.LogError("SpriteRenderer not found on the prefab.");
            }
        }
        else
        {
            Debug.LogError("No building prefab assigned in the script.");
        }

        root.Q<VisualElement>("root").style.display = DisplayStyle.None;
        isOpen = false;
        closeButton.clicked += OnCloseButtonClick;
    }

    // Update is called once per frame
    void Update()
    {
        // change text of the title
    }

    public void OnCloseButtonClick()
    {
        StartCoroutine(ToggleUI());
    }

    private IEnumerator ToggleUI()
    {
        this.isOpen = !this.isOpen;

        var root = GetComponent<UIDocument>().rootVisualElement;

        if (this.isOpen)
        {
            // Open instantly display flex
            root.Q<VisualElement>("root").style.display = DisplayStyle.Flex;
        }
        else
        {
            // Close instantly
            root.Q<VisualElement>("root").style.display = DisplayStyle.None;
        }

        yield return null; // Ensure that the Coroutine exits immediately
    }
}
