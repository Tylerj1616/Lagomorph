using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletspeed;
    private Rigidbody2D rb2d;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb2d.AddForce(transform.up * bulletspeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject,10);
    }
}
