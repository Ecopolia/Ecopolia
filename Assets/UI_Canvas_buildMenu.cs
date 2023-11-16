using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Canvas_buildMenu : MonoBehaviour
{
    public Button CloseButton;
    // Start is called before the first frame update
    void Start()
    {
        CloseButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
