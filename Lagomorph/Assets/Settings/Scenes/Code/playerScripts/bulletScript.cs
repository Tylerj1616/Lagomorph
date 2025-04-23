using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb2d;
    public float force;
    LayerMask mask;

    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	rb2d = GetComponent<Rigidbody2D>();
	mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
	Vector3 direction = mousePos - transform.position;
	Vector3 rotation = transform.position - mousePos;
	rb2d.velocity = new Vector2(direction.x, direction.y).normalized * force;
	float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
	transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    mask = LayerMask.GetMask("Walls");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
	    if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
	    {
	        enemyComponent.enemyTakeDamage(1);
	    }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == mask)
        {
            Destroy(this.gameObject);
        }
    }
}
