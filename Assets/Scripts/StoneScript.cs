using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class StoneScript : MonoBehaviour
{
    private bool isBuilt = false;
    public GameObject[] buildingPrefab;
    public GameObject buildMenu;
    public static StoneScript selectedStone; // Ajout de la variable statique


    private void OnMouseDown()
    {
        if(isBuilt){
            return;
        }
        buildMenu.SetActive(!buildMenu.gameObject.activeSelf);
        selectedStone = this; // Stockage de la pierre sélectionnée
    }


    public void ConstructBuilding(Building building)
    {
        if(!isBuilt){
            Instantiate(building, selectedStone.transform.position, Quaternion.identity);
            selectedStone.gameObject.SetActive(false);
            isBuilt = true;
        }
        buildMenu.SetActive(false);
    }
}
