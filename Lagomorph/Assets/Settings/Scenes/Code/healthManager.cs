using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	if (healthAmount <= 0)
	{
	    Application.LoadLevel(Application.loadedLevel);
	}

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
	    Destroy(GameObject.FindGameObjectWithTag("Player"));
	}
    }

    public void heal(float healingAmount)
    {
 	healthAmount += healingAmount;
	healthAmount = Mathf.Clamp(healthAmount, 0, 100);

	healthBar.fillAmount = healthAmount / 100f;
    }
}
