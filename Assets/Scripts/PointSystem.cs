using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public int lives;
    public GameObject end;
    public CharbyChar ch;
    public Image flashObject;  
    public float fadeDuration = 1.0f;
    public float visibleDuration = 0.5f;

    // Start is called before the first frame update
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
            ch.message = "Error 500: == Connection Terminated ==";

        }
    }

    public void Day(){
        end.SetActive(true);
        ch.message = "New Day.";
        StartCoroutine(Wait());
    }

    public void Ouch()
    {
        lives--;
        if (lives != 0)
        {
            StartCoroutine(FlashCoroutine());
        }

    }


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

    IEnumerator Wait()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(3f);  // wait for 3 seconds
        Debug.Log("3 seconds passed!");
        end.SetActive(false);
    }

}