using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
    public Material[] ballMaterialArray; 
    public Material ballColor;
    public bool ballMoveAct = true;
    public GameObject paintInkPrefab;
    public GameObject paintInkPrefabObj;
    public GameObject deathEffect;
    public GameObject deathRedEffect,deathYellowEffect,deathBlueEffect,deathGreenEffect;
    public float paintInkLifeTime = 4;
  
    System.Random _random = new System.Random(); 
    private Rigidbody _rigidbody;
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
        PaintInkAndEffectSelection(ballColor.name);
    }
    
    public void PaintInkAndEffectSelection(string colorName)
    {
        switch (colorName)
        {
            case "Blue" : 
                paintInkPrefabObj.transform.Find("Blue").gameObject.SetActive(true);
                deathEffect = deathBlueEffect;
                break;
            case "Green" : 
                paintInkPrefabObj.transform.Find("Green").gameObject.SetActive(true);
                deathEffect = deathGreenEffect;
                break;
            case "Red" : 
                paintInkPrefabObj.transform.Find("Red").gameObject.SetActive(true);
                deathEffect = deathRedEffect;
                break;
            case "Yellow" :
                paintInkPrefabObj.transform.Find("Yellow").gameObject.SetActive(true);
                deathEffect = deathYellowEffect;
                break;
        }
    }
    
    public void PaintInkCreateAndDestroy(Vector3 contactPoint, Transform parent)
    { 
        paintInkPrefabObj = Instantiate(paintInkPrefab, contactPoint, paintInkPrefab.transform.rotation, parent);
        Destroy(paintInkPrefabObj, paintInkLifeTime);
        PaintInkAndEffectSelection(ballColor.name);
    }
}
