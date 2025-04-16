using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Door");
        if (collision.gameObject.tag == "Player")
        {

            collision.transform.position = destination.transform.position;
        }
    }
}
 //collision.transform.position = destination.transform.position;