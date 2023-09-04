using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_rotation : MonoBehaviour
{
    Rigidbody physic;
    public int Rotation_speed;

    
    void Start()
    {
        physic = GetComponent<Rigidbody>();

        physic.angularVelocity = Random.insideUnitSphere*Rotation_speed;
    }

}
