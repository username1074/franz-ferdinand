using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class ImageController : MonoBehaviour
{
    public Image image;
    private string currentCategory;
    private int categoryIndex;
    private CardSystem cardSystem;
    public Button leftButton;
    public Button rightButton;
    public GameObject cardObjectPrefab;

    [SerializeField] public List<SpriteType> SpriteTypes;
    void Start()
    {

    }

    private void HandleSwipe(bool isSwipeRight)
    {
        if (isSwipeRight)
        {
            rightButton.onClick.Invoke();
        }
        else
        {
            leftButton.onClick.Invoke();
        }
    }

    public void NextImage()
    {
        List<Sprite> filtered = new List<Sprite>();

        foreach (var item in SpriteTypes)
        {
            if (item.category == currentCategory)
            {
                filtered.Add(item.sprite);
            }
        }

        if (filtered.Count == 0)
        {
            Debug.LogWarning("No images found for category: " + currentCategory);
            return;
        }

        categoryIndex = (categoryIndex + 1) % filtered.Count;
        //image.sprite = filtered[categoryIndex];

        MakeCard();

        cardSystem.SetSprite(filtered[categoryIndex]);
    }

    public void SetCategory(string category)
    {
        if (currentCategory != category)
        {
            currentCategory = category;
            categoryIndex = -1;
        }
    }

    public void OnCategorySelected(string newCategory)
    {
        SetCategory(newCategory);
    }



    public void ChangeImage(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found at path: " + filePath);
            return;
        }

        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D tex = new Texture2D(2, 2);
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


    private void MakeCard()
    {
        // Check game is still on
        if (PointSystem.IsGameOver()) return;

        // check no other card has already been made
        CardSystem[] cards = GameObject.FindObjectsOfType<CardSystem>();

        if (cards.Length > 0)
        {
            // destroy duplicates
            foreach (var card in cards)
            {
                if (!card.HasBeenSorted())
                {
                    card.Destroy();
                }
            }
        }

        var cardObject = Instantiate(cardObjectPrefab, Vector3.up, Quaternion.identity);
        cardObject.SetActive(true);
        cardSystem = cardObject.GetComponent<CardSystem>();
        cardSystem.OnSwiped += HandleSwipe;
    }
}
