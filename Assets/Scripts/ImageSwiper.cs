using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSwiper : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerClickHandler, IDragHandler
{
     public SwipeController swipeController;
     public TargetJoint2D targetJoint;
     public Transform faceObject;
     private Camera cam;
     private Vector2 startDragPos;
     private Vector2 endDragPos;
     private Vector2 currentDragPos;

     public void OnBeginDrag(PointerEventData eventData)
     {
          Debug.Log($"Began swipe");
          startDragPos = eventData.position;
     }

     public void OnDrag(PointerEventData eventData)
     {

          currentDragPos = eventData.position;

          var worldPoint = cam.ScreenToWorldPoint(currentDragPos);

          targetJoint.target = worldPoint;

          Debug.Log($"DRAGGING");
     }

     public void OnEndDrag(PointerEventData eventData)
     {
          Debug.Log($"eND swipe");
          endDragPos = eventData.position;
          float offset = endDragPos.x - startDragPos.x;

          bool isSwipeRight = (offset > 0);

          swipeController.Swipe(isSwipeRight);

          // this.gameObject.transform.position = new Vector2(50, 50);
     }

     public void OnPointerClick(PointerEventData eventData)
     {
          Debug.Log("CLKICK");
     }

     void Awake()
     {
          cam = Camera.main;
     }

     // Update is called once per frame
     void Update()
     {
          //transform.RotateAround

          //transform.parent.transform.RotateAround = new Vector3(-90, 0, currentDragPos.x / 1000);
          transform.parent.transform.LookAt(faceObject, Vector3.left);
          // this.gameObject.transform.Rotate
     }
}
