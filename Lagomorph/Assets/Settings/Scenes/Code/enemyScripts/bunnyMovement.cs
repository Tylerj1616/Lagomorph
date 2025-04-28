using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunnyMovement : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float rotateSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	if (!target)
	{
	    GetTarget();
	}
	else
	{
	    RotateTowardsTarget();
	}
    }

    private void FixedUpdate()
    {
	rb.velocity = transform.up * speed;
    }

    private void RotateTowardsTarget()
    {
	Vector2 targetDirection = target.position - transform.position;
	float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
	Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
	transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void GetTarget()
    {
	if (GameObject.FindGameObjectWithTag("Player"))
	{
	    target = GameObject.FindGameObjectWithTag("Player").transform;
	}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
	if (other.gameObject.CompareTag("Player"))
	{
	    Destroy(other.gameObject);
	    target = null;
	}
	else if (other.gameObject.CompareTag("Player"))
	{
	    Destroy(other.gameObject);
	    Destroy(gameObject);
	}
    }
}
