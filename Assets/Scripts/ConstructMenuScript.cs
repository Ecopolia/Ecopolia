using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructMenuScript : MonoBehaviour
{
    public StoneScript StoneScript;
    public Button[] buildingButtons; // tableau de boutons pour construire différents bâtiments

    void Start()
    {
        // Associer les fonctions de clic des boutons avec la méthode SelectedConstruct
        for (int i = 0; i < buildingButtons.Length; i++)
        {
            int choice = i; // stocker le choix dans une variable temporaire pour éviter les erreurs de portée
            buildingButtons[i].onClick.AddListener(() => SelectedConstruct(choice));
        }
    }

    void SelectedConstruct(int position)
    {
        StoneScript.selectedStone.ConstructBuilding(position);
    }
}
