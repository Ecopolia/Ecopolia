using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int money;
    public int wood;
    public SerializableDictionary<string, string> stone;
    public SerializableDictionary<string, float> stoneBuild;

    // Structure de la save
    public GameData() {
        this.money = 100;
        this.wood = 100;
        this.stone = new SerializableDictionary<string, string>();
        this.stoneBuild = new SerializableDictionary<string, float>();
    }
}
