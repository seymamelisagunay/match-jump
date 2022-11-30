using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public Transform lastSlot;
    System.Random _random = new System.Random();
    [SerializeField] private CirclesData circlesData = null;
    private Rigidbody _rigidbody;
    private Vector3 _moveValue;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveValue = transform.position;
    }
    private void FixedUpdate() 
    {
        if(circlesData.circleMoveAct)
        { 
            _moveValue += Vector3.up * circlesData.speed * Time.fixedDeltaTime; 
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
      Instantiate(circlesData.newCircles[_random.Next(0, circlesData.newCircles.Length)], spawnPoint, 
          Quaternion.Euler(new Vector3(0,_random.Next(0,12) * 30,0)), gameObject.transform);
    }

}
