using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Permet de changer de scene avec comme paramètre le nom de la scene à chargé
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
