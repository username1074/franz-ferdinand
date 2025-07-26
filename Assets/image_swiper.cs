using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class image_swiper : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerClickHandler, IDragHandler
{
    public SwipeController swipeController;
   private Vector2 startDragPos;
   private Vector2 endDragPos;

   public void OnBeginDrag(PointerEventData eventData)
   {
        Debug.Log($"Began swipe");
        startDragPos = eventData.position;
   }

   public void OnDrag(PointerEventData eventData)
   {

        Debug.Log($"DRAGGING");

   }

   public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log($"eND swipe");
        endDragPos = eventData.position;
        float offset = endDragPos.x - startDragPos.x;

        bool isSwipeRight = (offset > 0);

        swipeController.Swipe(isSwipeRight);

        this.gameObject.transform.position = new Vector2(50, 50);
    }

   public void OnPointerClick(PointerEventData eventData)
   {
        Debug.Log("CLKICK");
   }

   // Start is called before the first frame update
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
