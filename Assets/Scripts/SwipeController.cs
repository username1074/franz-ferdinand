using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField]
    public bool hasBeenSorted = false;
    public event Action<bool> OnSwiped;


    public void Swipe(bool isSwipeRight)
    {
        Debug.Log($"Swiped {isSwipeRight}");

        hasBeenSorted = true;
        // Call operator that processes swipes or do it here

        OnSwiped.Invoke(isSwipeRight);
    }

    public bool HasBeenSorted()
    {
        return hasBeenSorted;
    }
}
 