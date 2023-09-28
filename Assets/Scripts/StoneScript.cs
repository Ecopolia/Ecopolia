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
    public bool isMenu = false;
    public Building[] buildingPrefab;
    public GameObject buildMenu;
    public static StoneScript selectedStone;
    private Building build = null;
    private GameManager gm;

    void Start() {
        gm = FindObjectOfType<GameManager>();
    }
    private void OnMouseDown()
    {
        if(isBuilt || isMenu){
            return;
        }
        gm.SetMenu(true);
        // call coroutine active ici
        buildMenu.SetActive(!buildMenu.gameObject.activeSelf);
        selectedStone = this;
    }

    public void SetBuild(Building building) {
        if(building){
            isBuilt = true;
            build = building;
        }
        // call coroutine desactive ici
        buildMenu.SetActive(false);
        gm.SetMenu(false);
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
                    gm.ConstructBuilding(building, this);
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
