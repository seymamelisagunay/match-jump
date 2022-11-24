using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Circle Type",menuName = "Circle Type")]
public class CirclesData : ScriptableObject
{
    public GameObject[] newCircles;
    public float speed;
    public bool circleMoveAct = true;
   // public Transform lastSlot;
}
