using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using NaughtyAttributes;

public class ColorMatching : MonoBehaviour
{
    [SerializeField] private CirclesData circlesData = null;
    //private CircleController _circleController = new CircleController();
    private Vector3 _contactPoint;
    
    public BallController ballController;
    private void OnCollisionEnter(Collision collision)
    {
        _contactPoint = collision.contacts[0].point;
        
        if(collision.gameObject.CompareTag(ballController.ballColor.name))
        {
            Destroy(collision.collider.transform.parent.gameObject); 
        }
        else if(collision.gameObject.CompareTag("Death"))
        {
            
        }
        else if(collision.gameObject.CompareTag("Finish"))
        {
            
        }
        else
        {
            ballController.BallJump();
            ballController.PaintInkCreateAndDestroy(_contactPoint,collision.transform);
        }

    }

    [Button()]
    public void TestStop()
    {
       circlesData.circleMoveAct = false;
    }

}
