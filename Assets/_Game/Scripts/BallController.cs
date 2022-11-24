using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    System.Random _random = new System.Random();
    private Rigidbody _rigidbody;
    
    public Material[] ballMaterialArray; 
    public Material ballColor;
    public bool ballMoveAct = true;
    public GameObject paintInkPrefab;
    public float paintInkLifeTime = 4;
    
    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        BallRandomColor();
    }

    public void BallJump()
    {
        if (ballMoveAct)
        {
            _rigidbody.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
        }
    }

    public void BallRandomColor()
    {
        ballColor = ballMaterialArray[_random.Next(0, ballMaterialArray.Length)];
        GetComponent<Renderer>().sharedMaterial = ballColor;
        GetComponent<TrailRenderer>().sharedMaterial = ballColor;
        PaintInkColorChange(ballColor.name);
        //_material = GetComponent<TrailRenderer>().sharedMaterial;
    }
    
    public void PaintInkColorChange(string colorName)
    {
        foreach (Transform child in paintInkPrefab.transform)
        {
            child.gameObject.SetActive(false);
        }

        switch (colorName)
        {
            case "Blue" : 
                paintInkPrefab.transform.Find("Blue").gameObject.SetActive(true);
                break;
            case "Green" : 
                paintInkPrefab.transform.Find("Green").gameObject.SetActive(true);
                break;
            case "Red" : 
                paintInkPrefab.transform.Find("Red").gameObject.SetActive(true);
                break;
            case "Yellow" :
                paintInkPrefab.transform.Find("Yellow").gameObject.SetActive(true);
                break;
        }
    }
    
    public void PaintInkCreateAndDestroy(Vector3 contactPoint, Transform parent)
    {
        var newPaintInk =
            Instantiate(paintInkPrefab, contactPoint, paintInkPrefab.transform.rotation, parent) as GameObject;
        Destroy(newPaintInk, paintInkLifeTime);
    }
}
