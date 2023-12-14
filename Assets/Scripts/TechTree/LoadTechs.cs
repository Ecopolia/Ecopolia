using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI; 
using TMPro;


[XmlRoot("TechnologyTree")]
public class TechnologyTree
{
    [XmlElement("Technology")]
    public List<Technology> technologies = new List<Technology>();
}

[XmlType("Technology")]
public class Technology
{
    public int ID;
    public string Name;
    public string Description;
    public int CostGold;
    public int CostWood;
    public string State;

    public int ResearchTime;

    public int GoldBenefits;

    public int WoodBenefits;

    // Autres attributs

    public Technology() { } // Constructeur par défaut pour la sérialisation XML
}

public class LoadTechs : MonoBehaviour 
{
    public string xmlFileName; // Le nom de votre fichier XML
    private TechnologyTree techTree;
    public GameManager gm;
    private TechEngine techEngine;
    
    public void Start()
    {
        LoadDataFromXML();
        techEngine = gameObject.GetComponent<TechEngine>();
    }


    private TechnologyTree LoadDataFromXML()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TechnologyTree));
        using (FileStream stream = new FileStream(xmlFileName, FileMode.Open))
        {
            techTree = (TechnologyTree)serializer.Deserialize(stream);
        }
        gm.technologies = techTree.technologies;
        return techTree;
    }

}
