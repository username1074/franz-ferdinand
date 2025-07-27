using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointSystem : MonoBehaviour
{
    public int lives;
    public GameObject end;
    public Image flashObject;  
    public float fadeDuration = 1.0f;
    public float visibleDuration = 0.5f;

    void Start()
    {
        lives = 3;
        end.SetActive(false);
        flashObject.enabled = false;
    }

    void Update()
    {
        if (lives == 0)
        {
            end.SetActive(true);
        }
    }

/// <summary>
/// Reduce lives counter by one and flash the screen red
/// </summary>
    public void Ouch()
    {
        lives--;
        if (lives != 0)
        {
            StartCoroutine(FlashCoroutine());
        }
    }

/// <summary>
/// Run this when you take damage to flash the screen red
/// </summary>
    private IEnumerator FlashCoroutine()
    {
        flashObject.enabled = true;
        Color color = flashObject.color;
        color.a = 0.3f;
        flashObject.color = color;

        yield return new WaitForSeconds(visibleDuration);

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(0.3f, 0f, elapsed / fadeDuration);
            flashObject.color = color;
            yield return null;
        }

        color.a = 0f;
        flashObject.color = color;
        flashObject.enabled = false;
    }

}