using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class BallDeathEffect : MonoBehaviour
{
    [SerializeField] private CirclesData circlesData;
    public GameObject ball;
    private void OnCollisionEnter(Collision collision)
    {            
        if (collision.gameObject.CompareTag("Ball"))
        {
            circlesData.circleMoveAct = false;
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.GetComponent<SphereCollider>().enabled = false;
            ball.transform.DOScale(0f, 2f);
            GameObject effect = Instantiate(ball.GetComponent<BallController>().deathEffect, ball.transform.position, Quaternion.identity);
            Destroy(effect, 3);
        }
    }
    
}
