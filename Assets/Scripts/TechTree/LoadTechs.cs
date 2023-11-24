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
        skipButton = LoadingBar.GetComponentInChildren<Button>();
        skipButton.onClick.AddListener(() => {
                SkipWithGems();
            });
        LoadDataFromXML(); 
        specificTech = GetTechnologyByID(techId);
        if (specificTech != null)
        {
            FillButtonVariables(specificTech);
            //secondsRemaining = specificTech.ResearchTime;
        }
        GameObject go1 = new GameObject();
        go1.name = "TechCorotine" + techId;
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
        if (specificTech != null)
        {

                SetPopupText(pricePopUp, specificTech.CostGold +" "+specificTech.CostWood);
                SetPopupText(descriptionPopUp, "Description: " + specificTech.Description);
                SetPopupText(researchTimePopup, specificTech.ResearchTime + " s");
                SetPopupText(namePopUp, specificTech.Name);
                SetPopupText(effectPopUp, "Gold benefict: " + specificTech.GoldBenefits+ "Wood benefict :" + specificTech.WoodBenefits);

                pricePopUp.SetActive(true);
                descriptionPopUp.SetActive(true);
                researchTimePopup.SetActive(true);
                namePopUp.SetActive(true);
                effectPopUp.SetActive(true);
        }
            
        else
        {
            Debug.LogError("La référence à la technologie est manquante.");
        }
    }

    // Fonction utilitaire pour définir le texte d'un popup TextMeshProUGUI
    private void SetPopupText(GameObject popup, string text)
    {
        if (popup != null)
        {
            TextMeshProUGUI popupText = popup.GetComponentInChildren<TextMeshProUGUI>();
            if (popupText != null)
            {
                popupText.text = text;
            }
            else
            {
                Debug.LogError("Aucun composant TextMeshProUGUI trouvé dans le popup.");
            }
        }
        else
        {
            Debug.LogError("La référence au popup est manquante.");
        }
    }

    public void BuyTech()
    {
        if (specificTech != null && specificTech.State == "Locked")
        {
            int requiredGold = specificTech.CostGold;
            int requiredWood = specificTech.CostWood;

            if (gm.HasEnoughResources(requiredGold, requiredWood) && specificTech.State =="Locked")
            {
                // Déduisez le coût des ressources en utilisant GameManager
                gm.DeductResources(requiredGold, requiredWood);

                specificTech.State = "Upgrading";
                StartCoroutine(CompletePurchaseWithDelay());

            }
            else
            {
                Debug.Log("Insufficient resources to buy this technology.");
            }
        } else if (specificTech != null && specificTech.State == "Upgrading")
        {
            // TODO : this should   not happen because  of the following 
        }
        else
        {
            Debug.Log("Technology is already unlocked or not available.");
        }
    }

   private IEnumerator<WaitForSeconds> CompletePurchaseWithDelay()
    {
        secondsRemaining = specificTech.ResearchTime;
        var technologyButton = gameObject.GetComponent<Button>();
        LoadingBar.SetActive(true);
        while (secondsRemaining > 0)
        {
        SetPopupText(researchTimePopup, secondsRemaining + " s");            
        yield return new WaitForSeconds(1f);
            secondsRemaining--;
        }
        LoadingBar.SetActive(false);

        FillButtonVariables(specificTech);
        techEngine = gameObject.GetComponent<TechEngine>();
        technologyButton.GetComponentInChildren<TextMeshProUGUI>().text = "";

        techEngine.increaseMoney(specificTech.GoldBenefits);
        techEngine.increaseWood(specificTech.WoodBenefits);
        Debug.Log("Coroutine benefit used");
        UpdateTechStateInXML(specificTech.ID, "Unlocked");
        specificTech.State = "Unlocked";
    }

    private void SkipWithGems() {
        // 1 gems for 5 sec skip 
        if(gm.gemme >= secondsRemaining/5){
            gm.gemme -= secondsRemaining/5;
            secondsRemaining = 0;
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
