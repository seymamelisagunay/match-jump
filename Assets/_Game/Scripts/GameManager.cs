using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CirclesData circlesData;

    void Start()
    {
        circlesData.circleMoveAct = true;
    }

}
