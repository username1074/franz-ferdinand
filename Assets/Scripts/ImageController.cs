using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

public class ImageController : MonoBehaviour
{
    public Image image;    
    public Sprite[] images; 
    private int curr = 0;

    public void NextImage()
    {
        if (images.Length == 0) return;

        curr = (curr + 1) % images.Length;
        image.sprite = images[curr];
    }      
    public void ChangeImage(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found at path: " + filePath);
            return;
        }

        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D tex = new Texture2D(2, 2); // Dummy size; will auto-resize
        if (tex.LoadImage(fileData))
        {
            Sprite newImage = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.5f)
            );

            image.sprite = newImage;
        }
        else
        {
            Debug.LogError("Failed to load image from file.");
        }
    }
}
