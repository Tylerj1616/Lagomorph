using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
	if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
	{
	    transform.position = new Vector3 (178, 66, 0);
	}
    }
}
