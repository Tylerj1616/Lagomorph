using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFinalDoor : MonoBehaviour
{
    public GameObject FinalDoor;
    GameObject[] enemies;
    bool stopSpawn = false;

    void Update()
    {
	if(stopSpawn = false)
	{
	    enemies = GameObject.FindGameObjectsWithTag("Enemy");

	    if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
	    {
	        Instantiate(FinalDoor, transform.position, transform.rotation);

	        if(GameObject.FindGameObjectsWithTag("FinalTeleport").Length >= 1)
	        {
		    stopSpawn = true;
	        }
	    }
        }
    }
}
