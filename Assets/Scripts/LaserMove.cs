using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    Rigidbody physic;

    [SerializeField] float speed;

    private void Start()
    {
        physic = GetComponent<Rigidbody>();

        physic.velocity = transform.forward*speed;
    }
}
