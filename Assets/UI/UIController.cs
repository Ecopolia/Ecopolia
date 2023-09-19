using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public Label overviewGatherDataPerHour1;
    public Label overviewGatherDataPerHour2;
    public Label overviewGatherDataPerHour3;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        overviewGatherDataPerHour1 = root.Q<Label>("overview-ressource-gather-data-per-hour-1");
        overviewGatherDataPerHour2 = root.Q<Label>("overview-ressource-gather-data-per-hour-2");
        overviewGatherDataPerHour3 = root.Q<Label>("overview-ressource-gather-data-per-hour-3");
        
        overviewGatherDataPerHour1.text = "0";
        overviewGatherDataPerHour2.text = "0";
        overviewGatherDataPerHour3.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
