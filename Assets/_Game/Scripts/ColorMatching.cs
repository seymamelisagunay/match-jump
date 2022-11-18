using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class ColorMatching : MonoBehaviour
{
    public BallController ballController;
    private CircleController _circleController = new CircleController();
    //private Material _ballColorMaterial;
    private Vector3 _contactPoint;
    
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

}
