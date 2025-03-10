using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Aiming : MonoBehaviour
{
    private Vector3 mousePosition;
    //private Vector2 moveDirection;
    //public float movespeed;
    
    public Transform rb;
    public Camera sceneCamera;

    private Quaternion shootingRotation;

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
        //float moveX = Input.GetAxisRaw("Horizontal");
        //float moveY = Input.GetAxisRaw("Vertical");

        //Rotation


        //moveDirection = new Vector2(moveX, moveY).normalized;
        

        //Rotation
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Move()
    {

        //rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
        //Rotation
        Vector3 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        shootingRotation = Quaternion.Euler(0, 0, aimAngle - 90);
        Debug.Log(shootingRotation);
        //rb.rotation = aimAngle;
    }
}
    

