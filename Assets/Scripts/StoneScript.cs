using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public GameObject buildingPrefab; 
    // private void OnTouchDown()
    // {
    //     Debug.Log("Test");
    //     // Instancie le prefab du bâtiment à la position de la tuile
    //     //Instantiate(buildingPrefab, transform.position, Quaternion.identity);
    // }
        private void OnMouseDown()
    {
        Debug.Log("TestDown");
        Instantiate(buildingPrefab, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.identity);
    }
}