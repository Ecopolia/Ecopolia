using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake(){
        if(instance != null){
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
    }

    // Start is called before the first frame update
    private void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    // Permet de créer une nouvelle save
    public void NewGame() {
        this.gameData = new GameData();
    }

    // Load la save ou si rien n'est trouvé crée une nouvelle save
    public void LoadGame() {
        this.gameData = dataHandler.Load();

        if(this.gameData == null){
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

        foreach( IDataPersistence dataPersistenceObject in dataPersistenceObjects){
            dataPersistenceObject.LoadData(gameData);
        }

    }

    // Save les datas dans la save
    public void SaveGame() {
        foreach( IDataPersistence dataPersistenceObject in dataPersistenceObjects){
            dataPersistenceObject.SaveData( ref gameData);
        }

        dataHandler.Save(gameData);
    }

    // Save quand l'application est quitté
    private void OnApplicationQuit() {
        SaveGame();
    }

    // Récupère toutes les datas
    private List<IDataPersistence> FindAllDataPersistenceObjects() {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
