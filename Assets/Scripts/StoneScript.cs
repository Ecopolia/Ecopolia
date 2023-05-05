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
        buildMenu.SetActive(!buildMenu.gameObject.activeSelf);
        selectedStone = this; // Stockage de la pierre sélectionnée

    }

    public void ConstructBuilding(int choice)
    {
        if(!isBuilt){
            GameObject newBuilding = Instantiate(buildingPrefab[choice], new Vector3(transform.position.x, transform.position.y, 10), Quaternion.identity);
            // Utilisez "choice" pour déterminer quel type de bâtiment doit être instancié
            // ...
            isBuilt = true;
        }
        buildMenu.SetActive(false);
    }
}
