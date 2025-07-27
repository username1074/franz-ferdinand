
using System;
using System.Collections;
using System.Data.Common;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSwiper : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
     public GameObject cardParent;
     public SwipeController swipeController;
     public TargetJoint2D targetJoint;
     public Transform faceObject;
     private Camera mainCamera;
     private Vector2 startDragPos;
     private Vector2 endDragPos;
     private Vector2 currentDragPos;
     private bool isDragging;
     public float lifetime = 2;
     public float hoverSpeed = 1;
     public float offset = 0;
     public float variation = 0;
     public float amplitude = 1;
     public Vector2 initialPosition = Vector2.up * 1.5f;

     public void OnBeginDrag(PointerEventData eventData)
     {
          isDragging = true;

          startDragPos = eventData.position;

          Debug.Log($"Began swipe at {startDragPos}");
     }

     public void OnDrag(PointerEventData eventData)
     {
          if (!isDragging) return;

          currentDragPos = eventData.position;
          var worldPoint = mainCamera.ScreenToWorldPoint(currentDragPos);
          targetJoint.target = worldPoint;

          // Debug.Log($"Dragging at {currentDragPos}");
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

               Debug.Log($"Broadcasting Swipe");

               swipeController.Swipe(isSwipeRight);


               StartCoroutine(SendOffscreen(isSwipeRight));
          }
          else
          {
               Debug.Log($"Resetting target to initial position{Vector2.zero}");
               targetJoint.target = Vector2.zero + initialPosition;
          }
     }

     void Awake()
     {
          mainCamera = Camera.main;

          targetJoint.target = Vector2.zero + initialPosition;
          transform.parent.position = Vector3.zero;
     }

     // Update is called once per frame
     void Update()
     {
          transform.parent.transform.LookAt(faceObject, Vector3.left);

          if (!isDragging)
          {
               targetJoint.target = initialPosition + new Vector2(
                    Mathf.Sin(Time.timeSinceLevelLoad * hoverSpeed),
                    Mathf.Cos(Time.timeSinceLevelLoad * hoverSpeed * (1 + variation) + offset)
                    ) * amplitude;
          }

          // make the card float around a little to imply it is clickable
          transform.position = transform.parent.transform.position + new Vector3(
               Mathf.Sin(Time.timeSinceLevelLoad * hoverSpeed),
               Mathf.Cos(Time.timeSinceLevelLoad * hoverSpeed * (1 + variation) + offset),
               0) * amplitude;
     }

     private IEnumerator SendOffscreen(bool isSwipeRight)
     {
          Debug.Log($"Preparing to Delete");

          if (isSwipeRight)
          {
               StartCoroutine(AnimateMotion(30));
               //targetJoint.target = new Vector2(30, 0);
          }
          else
          {
               StartCoroutine(AnimateMotion(-30));
               //targetJoint.target = new Vector2(-30, 0);
          }

          yield return new WaitForSeconds(lifetime);

          Debug.Log("Destroying");

          Destroy(cardParent);
     }


     /// <summary>
     /// Run this when you take damage to flash the screen red
     /// </summary>
     private IEnumerator AnimateMotion(float finalX)
     {
          float elapsed = 0f;
          while (elapsed < lifetime)
          {
               elapsed += Time.deltaTime;
               targetJoint.target = new Vector2(Mathf.Lerp( 0 /*endDragPos.x*/, finalX, elapsed / lifetime), endDragPos.y);
               yield return null;
          }
     }
}
