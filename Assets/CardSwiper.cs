using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSwiper : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerClickHandler, IDragHandler
{
     public SwipeController swipeController;
     public TargetJoint2D targetJoint;
     public Transform faceObject;
     private Camera mainCamera;
     private Vector2 initialPos;
   private Vector2 startDragPos;
     private Vector2 endDragPos;
     private Vector2 currentDragPos;
   private bool isDragging;

   public void OnBeginDrag(PointerEventData eventData)
     {
          isDragging = true;

          Debug.Log($"Began swipe");
          startDragPos = eventData.position;
     }

     public void OnDrag(PointerEventData eventData)
     {
          if (!isDragging) return;

          currentDragPos = eventData.position;
          var worldPoint = mainCamera.ScreenToWorldPoint(currentDragPos);
          targetJoint.target = worldPoint;

          Debug.Log($"Dragging");
     }

     public void OnEndDrag(PointerEventData eventData)
     {
          isDragging = false;

          Debug.Log($"End swipe");

          endDragPos = eventData.position;
          float offset = endDragPos.x - startDragPos.x;
               
          if (Mathf.Abs(offset) > Screen.width / 3 /* replace with a number based on screen size */)
          {
               bool isSwipeRight = (offset > 0);
               swipeController.Swipe(isSwipeRight);
               SendOffscreen(isSwipeRight);
          }
          else
          {
               Debug.Log($"Resetting target to initial position{initialPos}");
               targetJoint.target = Vector2.zero;
          }
     }

     public void OnPointerClick(PointerEventData eventData)
     {
          Debug.Log("CLKICK");
     }

     void Awake()
     {
          mainCamera = Camera.main;


          targetJoint.target = Vector2.zero;    
          transform.parent.position = Vector3.zero;
          Debug.Log( $"initial position is :{initialPos}");
     }

     // Update is called once per frame
     void Update()
     {
          //transform.RotateAround

          //transform.parent.transform.RotateAround = new Vector3(-90, 0, currentDragPos.x / 1000);
          transform.parent.transform.LookAt(faceObject, Vector3.left);
          // this.gameObject.transform.Rotate
     }

     // Update is called once per frame
     void SendOffscreen(bool isSwipeRight)
     {
          //transform.RotateAround

          //transform.parent.transform.RotateAround = new Vector3(-90, 0, currentDragPos.x / 1000);

          if (isSwipeRight)
          {
               targetJoint.target = new Vector2(10, 0);
          }
          else
          {
               targetJoint.target = new Vector2(-10, 0);
          }

          transform.parent.transform.LookAt(faceObject, Vector3.left);
          // this.gameObject.transform.Rotate
     }
}
