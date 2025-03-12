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

    public static mainCharacterMovement instance;
    
    private void Awake()
    {
	instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
	rb2d = GetComponent<Rigidbody2D>();
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

    public IEnumerator Knockback(float kBDuration, float kBPower, Transform obj)
    {
	float timer = 0;

	while (kBDuration > timer)
	{
	    timer += Time.deltaTime;
	    Vector2 direction = (obj.transform.position -this.transform.position).normalized;
	    rb2d.AddForce(-direction * kBPower);
	}
	
	yield return 0;
    }

}