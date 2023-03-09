using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    private Button button;

    public void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        Debug.Log("Le bouton a été cliqué !");
    }

}