using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onehit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            Destroy(other.gameObject);
        }
    }
}

