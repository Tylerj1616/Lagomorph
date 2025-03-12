using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float EnemyHealth, enemyMax = 2f;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = enemyMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyTakeDamage(float enemyDamageAmount)
    {
	EnemyHealth -= enemyDamageAmount;

	if(EnemyHealth <= 0)
	{
	    Destroy(gameObject);
	}
    }
}
