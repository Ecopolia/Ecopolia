using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public GameObject parentGameObject;

    public void OnToggleButtonClick()
    {
        if (parentGameObject != null)
        {
            parentGameObject.SetActive(!parentGameObject.activeSelf);
            if(parentGameObject.activeSelf == true){
        LoadTechs loadTechsScript = GetComponentInParent<LoadTechs>();

        if (loadTechsScript != null)
        {
            // Appeler la méthode Start de LoadTechs
            loadTechsScript.Start();
        }
        else
        {
            Debug.LogError("Aucun script LoadTechs trouvé sur le parent GameObject (BG).");
        }

            }
        }
        else
        {
            Debug.LogError("Aucun parent GameObject défini pour le bouton de bascule.");
        }
    }
}