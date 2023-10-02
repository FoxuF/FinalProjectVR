using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class Gun : MonoBehaviour
{
    public Transform FirePoint;

    private void Update()
    {
        Shooting();
    }

    public void Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward)* hit.distance, Color.yellow);
        }
    }
}
