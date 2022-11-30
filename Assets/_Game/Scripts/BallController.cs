using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
    public Material[] ballMaterialArray; 
    public Material ballColor;
    public bool ballMoveAct = true;
    [HideInInspector] public GameObject paintInk;
    public GameObject paintInkRed, paintInkYellow, paintInkBlue, paintInkGreen;
    [HideInInspector] public GameObject deathEffect;
    public GameObject deathRedEffect,deathYellowEffect,deathBlueEffect,deathGreenEffect;
    public float paintInkLifeTime = 1.5f;
  
    System.Random _random = new System.Random(); 
    private Rigidbody _rigidbody;
    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        BallRandomColor();
        PaintInkAndEffectSelection(ballColor.name);
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
        
    }
    
    public void PaintInkAndEffectSelection(string colorName)
    {
        switch (colorName)
        {
            case "Blue" : 
                paintInk = paintInkBlue;
                deathEffect = deathBlueEffect;
                break;
            case "Green" : 
                paintInk = paintInkGreen;
                deathEffect = deathGreenEffect;
                break;
            case "Red" : 
                paintInk = paintInkRed;
                deathEffect = deathRedEffect;
                break;
            case "Yellow" :
                paintInk = paintInkYellow;
                deathEffect = deathYellowEffect;
                break;
        }
    }
    
    public void PaintInkCreateAndDestroy(Vector3 contactPoint, Transform parent)
    {
        var instanceObject = Instantiate(paintInk, contactPoint, paintInk.transform.rotation, parent);
        Destroy(instanceObject, paintInkLifeTime);
    }
}
