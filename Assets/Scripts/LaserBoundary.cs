using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
