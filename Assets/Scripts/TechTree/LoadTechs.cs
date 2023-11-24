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

    public int techId;
    public GameObject pricePopUp;
    public GameObject descriptionPopUp;
    public GameObject researchTimePopup;
    public GameObject namePopUp;
    public GameObject effectPopUp;


    private TechnologyTree techTree;
    private Button technologyButton;
    private Button skipButton;

    public GameManager gm;

    public GameObject LoadingBar;

    private TechEngine techEngine;

    private Technology specificTech;

    private int secondsRemaining;

    public void Start()
    {

        Debug.Log(LoadDataFromXML()); 
        Debug.Log(techTree.technologies);

     
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
