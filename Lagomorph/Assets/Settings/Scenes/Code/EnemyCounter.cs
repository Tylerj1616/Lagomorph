using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    GameObject[] enemies;
    public TMP_Text enemyCountText;
    
    void Start()
    {

    }

    
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemyCountText.text = "Enemies : " + enemies.Length.ToString();

	if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
	{
	    enemyCountText.text = "Find the door in the spider level.";
	}

	if(GameObject.FindGameObjectsWithTag("evilRabbit").Length == 0)
	{
	    enemyCountText.text = "WIN";
	}
    }
}
