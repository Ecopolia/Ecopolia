using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject boundaryObject; // Ajoutez votre objet avec le BoxCollider ici
    private Vector3 lastPosition;

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            lastPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 delta = Input.GetTouch(0).deltaPosition;
            Vector3 delta3 = new Vector3(-delta.x, -delta.y, 0f);

            // Met à jour la position de la caméra en fonction de la direction du vecteur de déplacement
            transform.Translate(delta3 * speed);

            if (boundaryObject != null && boundaryObject.GetComponent<BoxCollider>() != null)
            {
                // Récupère les dimensions du BoxCollider de l'objet
                Vector3 objectSize = boundaryObject.GetComponent<BoxCollider>().size;

                // Calcule les limites minimales et maximales en fonction de la position de l'objet et de la moitié de la taille de la caméra
                float mapMinX = boundaryObject.transform.position.x - objectSize.x / 2 + Camera.main.orthographicSize * Camera.main.aspect;
                float mapMaxX = boundaryObject.transform.position.x + objectSize.x / 2 - Camera.main.orthographicSize * Camera.main.aspect;
                float mapMinY = boundaryObject.transform.position.y - objectSize.y / 2 + Camera.main.orthographicSize;
                float mapMaxY = boundaryObject.transform.position.y + objectSize.y / 2 - Camera.main.orthographicSize;

                // Limite la position de la caméra en fonction des valeurs minimales et maximales calculées
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, mapMinX, mapMaxX),
                    Mathf.Clamp(transform.position.y, mapMinY, mapMaxY),
                    transform.position.z
                );
            }

            lastPosition = Input.GetTouch(0).position;
        }
    }
}