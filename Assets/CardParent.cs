using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardParent : MonoBehaviour
{
    public TargetJoint2D targetJoint2D;
    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = Vector3.zero;
    }

    // // Update is called once per frame
    // void Awake()
    // {
    //     transform.position = Vector3.zero;
    //     targetJoint2D.target = Vector2.zero;
    //     transform.LookAt(pivot);
    // }
}
