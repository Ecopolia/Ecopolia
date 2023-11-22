using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int money;
    public int wood;
    public int gemme;
    public float temperature;
    public float air;
    public string saison;
    public float rain;
    public float voierie;
    public SerializableDictionary<string, string> stone;
    public SerializableDictionary<string, float> stoneBuild;

    // Structure de la save
    public GameData() {
        this.money = 100;
        this.wood = 100;
        this.gemme = 5;
        this.temperature = 25;
        this.air = 1;
        this.saison = "été";
        this.rain = 5;
        this.voierie = 1;
        this.stone = new SerializableDictionary<string, string>();
        this.stoneBuild = new SerializableDictionary<string, float>();
    }
}
