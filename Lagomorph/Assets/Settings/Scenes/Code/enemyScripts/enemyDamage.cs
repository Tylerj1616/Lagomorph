using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public healthManager playerHealth;
    public int damage = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
	if(other.gameObject.tag == "Player")
	{
	    playerHealth.takeDamage(damage);
	}
    }
}
