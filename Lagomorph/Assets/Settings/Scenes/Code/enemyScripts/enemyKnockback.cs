using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKnockback : MonoBehaviour
{
    public float kBPower = 100;
    public float kBDuration = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
	if(other.gameObject.tag == "Player")
	{
	    StartCoroutine(mainCharacterMovement.instance.Knockback(kBDuration, kBPower, this.transform));
	}
    }
}
