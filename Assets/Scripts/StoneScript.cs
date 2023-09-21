using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class StoneScript : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate unique id")]
    private void GenerateId(){
        id = System.Guid.NewGuid().ToString();
    }
    private bool isBuilt = false;
    private bool isMenu = false;
    public Building[] buildingPrefab;
    public GameObject buildMenu;
    public static StoneScript selectedStone;
    private Building build = null;
    private GameManager gm;

    private void OnMouseDown()
    {
        if(isBuilt || isMenu){
            return;
        }
        isMenu = true;
        buildMenu.SetActive(!buildMenu.gameObject.activeSelf);
        selectedStone = this;
    }


    public void ConstructBuilding(Building building)
    {
        if (!isBuilt)
        {
            Instantiate(building, this.transform.position + new Vector3(0, 0, 50), Quaternion.identity);
            this.gameObject.SetActive(false);
            isBuilt = true;
            build = building;
        }
        buildMenu.SetActive(false);
        isMenu = false;
    }

    public void LoadData(GameData data){
        string idBuilding;

        gm = FindObjectOfType<GameManager>();

        if (data.stone.TryGetValue(id, out idBuilding))
        {
            foreach (Building building in buildingPrefab)
            {
                if (building.id == idBuilding)
                {
                    gm.buildings.Add(building);
                    ConstructBuilding(building);
                }
            }
        }
    }

    public void SaveData(ref GameData data){
        if(data.stone.ContainsKey(id)){
            data.stone.Remove(id);
        }

        data.stone.Add(id, build ? build.id : null);
    }
}
