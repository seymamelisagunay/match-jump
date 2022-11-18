using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using NaughtyAttributes;
public class CircleController : MonoBehaviour
{
    System.Random _random = new System.Random();
    
    public GameObject[] newCircles;
    public float speed;
    public bool circleMoveAct = true;
    public Transform lastSlot;
    private Rigidbody _rigidbody;
    private Vector3 _moveValue;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveValue = transform.position;
    }
    private void FixedUpdate() 
    {
        if(circleMoveAct)
        { 
            _moveValue += Vector3.up * speed * Time.fixedDeltaTime; 
            _rigidbody.MovePosition(_moveValue); 
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UpperCircle"))
        {
            Destroy(transform.GetChild(0).gameObject);
            CreateCircle(lastSlot.position);
        }
    }
    
    private void CreateCircle(Vector3 spawnPoint)
    {
      Instantiate(newCircles[_random.Next(0, newCircles.Length)], spawnPoint, 
          Quaternion.Euler(new Vector3(0,_random.Next(0,12) * 30,0)), gameObject.transform);
    }
    [Button()]
    public void CircleMoveStop()
    {
        circleMoveAct = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
    [Button()]
    public void CircleMoveStart()
    {
        circleMoveAct = true;
       // _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                                 RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    
}
