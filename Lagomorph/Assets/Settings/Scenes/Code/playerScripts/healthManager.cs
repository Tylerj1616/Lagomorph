using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount;
    public int maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
	{
	    takeDamage(20);
	}

	if (Input.GetKeyDown(KeyCode.Space))
	{
	    heal(5);
	}
    }

    public void takeDamage(float damage)
    {
	healthAmount -= damage;
	healthBar.fillAmount = healthAmount / 100f;

	if(healthAmount <= 0)
	{
	    Destroy(gameObject);
	}
    }

    public void heal(float healingAmount)
    {
 	healthAmount += healingAmount;
	healthAmount = Mathf.Clamp(healthAmount, 0, 100);

	healthBar.fillAmount = healthAmount / 100f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
	if(other.gameObject.tag == "HealthPickup")
	{
	    heal(20);
	}
	else if(other.gameObject.tag == "evilBullet")
	{
	    takeDamage(30);
	}
    }
}
