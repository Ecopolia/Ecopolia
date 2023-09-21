using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_BuildMenu_Conroller : MonoBehaviour
{
    public Button closeButton;

    public Button OpenButton;

    public Label buildMenuTitle;

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Build Menu Controller started");
        var root = GetComponent<UIDocument>().rootVisualElement;
        closeButton = root.Q<Button>("buildmenu-shop-close");
        buildMenuTitle = root.Q<Label>("buildmenu-shop-title");

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
