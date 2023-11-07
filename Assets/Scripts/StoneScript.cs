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
    public bool isBuilt = false;
    public bool isMenu = false;
    public Building[] buildingPrefab;
    public GameObject buildMenu;
    public static StoneScript selectedStone;
    public Building build = null;
    private GameManager gm;

    // Start is called before the first frame update
    void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    // Quand un clique sur l'objet est réaliser déclenche la fonction
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

    // Permet de set le batiment à la stone avec comme paramètre le batiment
    public void SetBuild(Building building) {
        if(building){
            isBuilt = true;
            build = building;
        }
        // call coroutine desactive ici
        buildMenu.SetActive(false);
        gm.SetMenu(false);
    }

    // Load les datas de la save
    public void LoadData(GameData data){
        string idBuilding;
        float timeLeft;

        gm = FindObjectOfType<GameManager>();

        if (data.stone.TryGetValue(id, out idBuilding))
        {
            foreach (Building building in buildingPrefab)
            {
                if (building.id == idBuilding)
                {
                    if (data.stoneBuild.TryGetValue(id, out timeLeft)){
                        gm.ConstructBuilding(building, this, null, timeLeft);
                    } else {
                        gm.ConstructBuilding(building, this);
                    }

                    gm.buildings.Add(building);
                }
            }
        }
    }

    // Save les datas sur la save
    public void SaveData(ref GameData data){
        if(data.stone.ContainsKey(id)){
            data.stone.Remove(id);
        }

        data.stone.Add(id, build ? build.id : null);

        if(data.stoneBuild.ContainsKey(id)){
            data.stoneBuild.Remove(id);
        }

        data.stoneBuild.Add(id, build ? build.timeLeft : 0);
    }
}
