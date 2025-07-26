using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{

    public void Swipe (bool isSwipeRight)
    {
        Debug.Log($"Swiped {isSwipeRight}");
    }
}
