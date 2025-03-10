using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public Camera sceneCamera;

    public float movespeed;

    public Rigidbody2D rb;

    public Weapon weapon;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

    private void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {

        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Rotation
        /*
        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
        */

        moveDirection = new Vector2(moveX, moveY).normalized;

        //Rotation
        //mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);

        //Rotation
        /*
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
        */
    }


}
