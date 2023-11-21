using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    
    public float temperature; // Temperature du monde
    public float air; // Qualité de l'air pouvant varier de 0 à 1 / 0 mauvaise - 1 bonne
    public string saison; // Saison en cours été/automne/hiver/printemps
    public float rain; // Centimètre² de pluie  
    public float voierie; // Qualité de la voierie pouvant varier de 0 à 1 / 0 mauvaise - 1 bonne

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Load la data de la save
    public void LoadData(GameData data){
        this.temperature = data.temperature;
        this.air = data.air;
        this.saison = data.saison;
        this.rain = data.rain;
        this.voierie = data.voierie;
    }

    // Save la data dans la save
    public void SaveData(ref GameData data){
        data.temperature = this.temperature;
        data.air = this.air;
        data.saison = this.saison;
        data.rain = this.rain;
        data.voierie = this.voierie;
    }
}
