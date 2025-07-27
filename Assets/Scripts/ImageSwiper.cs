
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSwiper : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerClickHandler, IDragHandler
{
     public SwipeController swipeController;
     public TargetJoint2D targetJoint;
     public Transform faceObject;
     private Camera mainCamera;
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
          var worldPoint = mainCamera.ScreenToWorldPoint(currentDragPos);
          targetJoint.target = worldPoint;

          Debug.Log($"Dragging");
     }

     public void OnEndDrag(PointerEventData eventData)
     {
          Debug.Log($"End swipe");
          endDragPos = eventData.position;
          float offset = endDragPos.x - startDragPos.x;
          bool isSwipeRight = (offset > 0);
          swipeController.Swipe(isSwipeRight);

          // this.gameObject.transform.position = new Vector2(50, 50);

          if (false && Mathf.Abs(offset) > 10 /* replace with a number based on screen size */)
          {
               SendOffscreen();
          }
          else
          {
               // reset target to center of screen
               // #todo

               var centreOfScreen = new Vector2 (Screen.width, Screen.height);

               // var centreOfScreen = Screen.size / 2;

               var worldPoint = mainCamera.ScreenToWorldPoint(centreOfScreen);
               targetJoint.target = worldPoint ;
          }
     }

     public void OnPointerClick(PointerEventData eventData)
     {
          Debug.Log("CLKICK");
     }

     void Awake()
     {
          mainCamera = Camera.main;
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
     void SendOffscreen()
     {
          //transform.RotateAround

          //transform.parent.transform.RotateAround = new Vector3(-90, 0, currentDragPos.x / 1000);
          transform.parent.transform.LookAt(faceObject, Vector3.left);
          // this.gameObject.transform.Rotate
     }
}
