
using System;
using UnityEngine;

public class CardSystem : MonoBehaviour
{
    public event Action<bool> OnSwiped;
    public SpriteRenderer spriteRenderer;
    public SwipeController swipeController;

    // Start is called before the first frame update
    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    void Awake()
    {
        // Check game is still on
        if (PointSystem.IsGameOver()) GameObject.Destroy(gameObject);

        swipeController.OnSwiped += HandleSwipe;
    }

    private void HandleSwipe(bool isSwipeRight)
    {
        OnSwiped.Invoke(isSwipeRight);
    }

    public bool HasBeenSorted()
    {
        return swipeController.HasBeenSorted();
    }
    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}