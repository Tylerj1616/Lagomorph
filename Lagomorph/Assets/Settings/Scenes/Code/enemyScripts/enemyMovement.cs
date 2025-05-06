using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform player;
    private bool inRange;
    public float followPlayerRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= followPlayerRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
	else
	{

	}
    }
}
