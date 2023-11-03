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
    private TechnologyTree techTree;
    private Button technologyButton;

    public GameManager gameManager;

    private TechEngine techEngine;

    private Technology specificTech;
    private void Start()
    {
        
        LoadDataFromXML(); 
        specificTech = GetTechnologyByID(techId);
        if (specificTech != null)
        {
            FillButtonVariables(specificTech);
        }
        
    }

    private TechnologyTree LoadDataFromXML()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TechnologyTree));
        using (FileStream stream = new FileStream(xmlFileName, FileMode.Open))
        {
            techTree = (TechnologyTree)serializer.Deserialize(stream);
        }
        return techTree;
    }

    private Technology GetTechnologyByID(int id)
    {
        foreach (Technology tech in techTree.technologies)
        {
            if (tech.ID == id)
            {
                return tech;
            }
        }
        return null; 
    }


    private void FillButtonVariables(Technology specificTech)
    {
        // Accédez au composant Button directement
        var technologyButton = gameObject.GetComponent<Button>();


        if (technologyButton != null && specificTech != null)
        {
            // Remplissez les variables du bouton avec les données de specificTech
            var buttonText = technologyButton.GetComponentInChildren<TextMeshProUGUI>();
            var buttonImage = technologyButton.GetComponent<Image>();

            if (buttonText != null)
            {
                string buttonLabel = specificTech.Name + "\n" +
                                    "Description: " + specificTech.Description + "\n" +
                                    "Gold Cost: " + specificTech.CostGold + "\n" +
                                    "Wood Cost: " + specificTech.CostWood;

                if (specificTech.State == "Locked")
                    {
                        buttonLabel += "\nResearch Time: " + specificTech.ResearchTime + " seconds";}
                 
                buttonText.text = buttonLabel;
            }

            if (buttonImage != null)
            {
                if (specificTech.State == "Locked")
                {
                    buttonImage.color = Color.red;
                }
                else
                {
                    buttonImage.color = Color.green;
                }
            }
        }
    }

    public void BuyTech()
    {
        if (specificTech != null && specificTech.State == "Locked")
        {
            int requiredGold = specificTech.CostGold;
            int requiredWood = specificTech.CostWood;

            if (gameManager.HasEnoughResources(requiredGold, requiredWood) && specificTech.State =="Locked")
            {
                // Déduisez le coût des ressources en utilisant GameManager
                gameManager.DeductResources(requiredGold, requiredWood);

                specificTech.State = "Unlocked";
                StartCoroutine(CompletePurchaseWithDelay(specificTech.ResearchTime));

            }
            else
            {
                Debug.Log("Insufficient resources to buy this technology.");
            }
        }
        else
        {
            Debug.Log("Technology is already unlocked or not available.");
        }
    }

   private IEnumerator<WaitForSeconds> CompletePurchaseWithDelay(int delais)
    {
        int secondsRemaining = delais;
        var technologyButton = gameObject.GetComponent<Button>();

        while (secondsRemaining > 0)
        {
            technologyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Recherche en cours... (" + secondsRemaining + "s)";
            yield return new WaitForSeconds(1f);
            secondsRemaining--;
        }
        FillButtonVariables(specificTech);
        techEngine = gameObject.GetComponent<TechEngine>();
        
        techEngine.increaseMoney(specificTech.GoldBenefits);
        techEngine.increaseWood(specificTech.WoodBenefits); // rajoutez l'id du batiment si on veut focus un batiment en particulier
        UpdateTechStateInXML(specificTech.ID, "Unlocked");
    }
  
    private void SaveDataToXML(TechnologyTree techTree)
{
    XmlSerializer serializer = new XmlSerializer(typeof(TechnologyTree));
    using (FileStream stream = new FileStream(xmlFileName, FileMode.Create))
    {
        serializer.Serialize(stream, techTree);
    }
}
public void UpdateTechStateInXML(int techId, string newState)
{
    TechnologyTree techTree = LoadDataFromXML();

    Technology specificTech = techTree.technologies.Find(tech => tech.ID == techId);

    if (specificTech != null)
    {
        specificTech.State = newState;

        SaveDataToXML(techTree);
    }
}
}
