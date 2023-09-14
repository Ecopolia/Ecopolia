using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTD_VisualEffect : MonoBehaviour
{
    public GameObject visualEffectPrefab;
    public float effectDuration = 2.0f;
    public float zOffset = 100f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 tapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tapPosition.z = zOffset;
            GameObject effectInstance = Instantiate(visualEffectPrefab, tapPosition, Quaternion.identity);
           
            Destroy(effectInstance, effectDuration);
        }
    }
}
