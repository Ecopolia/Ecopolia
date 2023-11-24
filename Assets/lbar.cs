using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class lbar : MonoBehaviour
{
    public GameObject gameObjectWithImage;
    public Sprite[] sprites;
    public float animationSpeed = 0.1f; // Adjust the speed of the animation
    private int currentSpriteIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimateLoadingBar());
    }

    IEnumerator AnimateLoadingBar()
    {
        while (true)
        {
            if (sprites.Length == 0)
            {
                Debug.LogError("No sprites assigned to the array.");
                yield break;
            }

            // Set the sprite based on the current index
            gameObjectWithImage.GetComponent<Image>().sprite = sprites[currentSpriteIndex];

            // Move to the next sprite index
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;

            // Wait for a short duration before changing to the next sprite
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}
