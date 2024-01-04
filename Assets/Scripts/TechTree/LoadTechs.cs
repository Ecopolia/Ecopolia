using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

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

    // Other attributes

    public Technology() { } // Default constructor for XML serialization
}

public class LoadTechs : MonoBehaviour
{

    // Enum to represent different types of benefits
    enum BenefitType
    {
        Boost,
        Enhancer,
        Advantage,
        
        Technology // Default if no specific benefit is determined
    }
    public string xmlFileName;
    private TechnologyTree techTree;
    public GameManager gm;
    private TechEngine techEngine;

    public void Start()
    {
        LoadDataFromXML();
        GenerateAndSaveNewTechsIfEmpty();
        techEngine = gameObject.GetComponent<TechEngine>();
    }

    private void LoadDataFromXML()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TechnologyTree));
        try
        {
            using (FileStream stream = new FileStream(xmlFileName, FileMode.Open))
            {
                techTree = (TechnologyTree)serializer.Deserialize(stream);
            }
        }
        catch (FileNotFoundException)
        {
            // File not found, create a new TechnologyTree
            techTree = new TechnologyTree();
        }

        gm.technologies = techTree.technologies;
    }

    private void GenerateAndSaveNewTechsIfEmpty()
    {
        // Check if the file exists and is not empty
        if (File.Exists(xmlFileName) && new FileInfo(xmlFileName).Length > 0)
        {
            // File exists and is not empty, leave it as is
            return;
        }

        // Generate new technologies
        List<Technology> newTechs = GenerateTechnologyTree(3);

        // Add new technologies to the existing ones
        techTree.technologies.AddRange(newTechs);

        // Save the updated technology tree to the XML file
        SaveDataToXML();
    }

    private void SaveDataToXML()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TechnologyTree));
        using (FileStream stream = new FileStream(xmlFileName, FileMode.Create))
        {
            serializer.Serialize(stream, techTree);
        }
    }

    private List<Technology> GenerateTechnologyTree(int depth)
    {
        List<Technology> newTechs = new List<Technology>();

        for (int i = 1; i <= depth; i++)
        {
            Technology tech = new Technology
            {
                ID = techTree.technologies.Count + i,
                Name = GenerateEcoName(),
                Description = GenerateDescription(),
                CostGold = UnityEngine.Random.Range(0, 20),
                CostWood = UnityEngine.Random.Range(0, 20),
                State = "Locked",
                ResearchTime = UnityEngine.Random.Range(1, 10) * 100,
                GoldBenefits = UnityEngine.Random.Range(0, 10),
                WoodBenefits = UnityEngine.Random.Range(0, 10),
            };

            newTechs.Add(tech);
        }

        return newTechs;
    }

    string GenerateEcoName()
    {
        string[] prefixes = { "Eco", "Green", "Sustainable", "Nature", "Harmony" };
        string[] suffixes = { "City", "Village", "Settlement", "Haven", "Oasis" };

        string prefix = prefixes[UnityEngine.Random.Range(0, prefixes.Length)];
        string suffix = suffixes[UnityEngine.Random.Range(0, suffixes.Length)];

        // Determine the benefit type
        BenefitType benefitType = DetermineBenefitType();

        return $"{prefix} {benefitType} {suffix}";
    }

    private BenefitType DetermineBenefitType()
    {
        bool hasGoldBenefit = UnityEngine.Random.Range(0, 2) == 0; // 50% chance of having a gold benefit
        bool hasWoodBenefit = UnityEngine.Random.Range(0, 2) == 0; // 50% chance of having a wood benefit

        if (hasGoldBenefit && hasWoodBenefit)
        {
            return BenefitType.Advantage;
        }
        else if (hasGoldBenefit)
        {
            return BenefitType.Boost;
        }
        else if (hasWoodBenefit)
        {
            return BenefitType.Enhancer;
        }

        return BenefitType.Technology; // Default if no specific benefit is determined
    }


    string GenerateDescription()
    {
        BenefitType benefitType = DetermineBenefitType();

        switch (benefitType)
        {
            case BenefitType.Advantage:
                return "Provides both gold and wood benefits, offering a significant advantage.";
            case BenefitType.Boost:
                return "Gives a boost to gold production.";
            case BenefitType.Enhancer:
                return "Enhances wood production.";
            // Add new cases for additional benefit types
            default:
                return "Unlocks advanced technologies for ecological development.";
        }
    }
}
