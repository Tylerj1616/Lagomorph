using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    public SpriteRenderer _spritePlayer;
    private Vector2 moveInput;
    [SerializeField] private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
	moveInput.x = Input.GetAxisRaw("Horizontal");
	moveInput.y = Input.GetAxisRaw("Vertical");

	moveInput.Normalize();

	rb2d.velocity = moveInput * moveSpeed;

	if (moveInput.x > 0f)
	{
	    _spritePlayer.flipX = false;
	}
	else
	{
	    _spritePlayer.flipX = true;
	}

	if (moveInput.x != 0 || moveInput.y != 0)
	{
	    _animator.SetBool("isRunning", true);
	}
	else
	{
	    _animator.SetBool("isRunning", false);
	}
    }
}