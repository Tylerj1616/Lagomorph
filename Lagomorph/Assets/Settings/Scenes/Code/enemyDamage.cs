using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public int damage = 15;
    public Health healthAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
	if (healthAmount == null)
	{
	    healthAmount = collision.gameObject.GetComponent<healthManager>();
	}
	
	healthAmount.TakeDamage(damage);
    }
}
