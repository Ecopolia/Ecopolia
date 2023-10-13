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

    public GameData() {
        this.money = 15;
        this.wood = 20;
        this.stone = new SerializableDictionary<string, string>();
        this.stoneBuild = new SerializableDictionary<string, float>();
    }
}
