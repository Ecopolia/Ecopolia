using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public float speed = 0.1f;
    private Vector3 lastPosition;

    void Update()
    {
        // Vérifie si l'utilisateur a commencé à glisser le doigt sur l'écran
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            lastPosition = Input.GetTouch(0).position;
        }

        // Vérifie si l'utilisateur continue de glisser son doigt sur l'écran
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Calcule le vecteur de déplacement entre la position actuelle du doigt et sa dernière position
            Vector2 delta = Input.GetTouch(0).deltaPosition;

            // Convertit le vecteur de type Vector2 en un vecteur de type Vector3 en ajoutant une valeur Z nulle
            Vector3 delta3 = new Vector3(-delta.x, -delta.y, 0f);

            // Déplace la caméra en fonction de la direction du vecteur de déplacement
            transform.Translate(delta3 * speed);

            // Met à jour la dernière position connue du doigt
            lastPosition = Input.GetTouch(0).position;
        }
    }
    
}
