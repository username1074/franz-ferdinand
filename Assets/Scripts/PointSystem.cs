using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public static int lives = 3;
    public GameObject end;
    //public Canvas canvas;
    public Image flashObject;
    public CharbyChar ch;
    public float fadeDuration = 1.0f;
    public float visibleDuration = 0.5f;
    // [SerializeField] private int day = 1;

    void Start()
    {
        lives = 3;
        end.SetActive(false);
        flashObject.enabled = false;
    }

    public void Day()
    {
        ch.ClearTextBox();
        end.SetActive(true);
        ch.message = "New Day.";
        StartCoroutine(Wait());
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

        if (lives == 0)
        {
            ch.ClearTextBox();
            end.SetActive(true);
            ch.message = "Error 500: == Connection Terminated ==";
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        Debug.Log("Ending Game");

        yield return new WaitForSeconds(0.1f);

        end.SetActive(true);

        // Destroy all cards so they are no longer visible
        CardSystem[] cards = GameObject.FindObjectsOfType<CardSystem>();
        foreach (var card in cards)
        {
            Debug.Log("Destroying Cards");
            GameObject.Destroy(card.gameObject);
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

    public static bool IsGameOver()
    {
        return lives < 1;
    }
    
    IEnumerator Wait()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(3f);  // wait for 3 seconds
        Debug.Log("3 seconds passed!");
        end.SetActive(false);
    }
}