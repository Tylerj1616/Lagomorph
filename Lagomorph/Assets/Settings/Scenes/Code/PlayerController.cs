using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Rigidbody2D rb2d;
    private GameManager gameManager;

    public Quaternion shootingRotation;

    public AudioClip deathSoundEffect;
    public AudioClip meleeSoundEffect;
    public AudioClip gunSoundEffect;
    public AudioClip emptyGunSoundEffect;

    public float staminaLengthInSeconds;

    private AudioSource soundClip;
    private bool gunSound, meleeSound, running, tired;
    private float stamina, moveSpeedActual;
    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        soundClip = gameObject.GetComponent<AudioSource>();
        stamina = staminaLengthInSeconds;
        moveSpeedActual = moveSpeed;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {


        if (Input.GetAxis("Fire1") > 0 && !gunSound)
        {
            if (gameManager.getAmmo() > 0)
            {
                soundClip.PlayOneShot(gunSoundEffect, 1);
            }
            else
            {
                soundClip.PlayOneShot(emptyGunSoundEffect, 1);
            }
            gunSound = true;
        }
        else if (Input.GetAxis("Fire1") == 0)
        {
            gunSound = false;
        }
        if (Input.GetAxis("Fire2") > 0 && !meleeSound)
        {
            soundClip.PlayOneShot(meleeSoundEffect, 1);
            meleeSound = true;
        }
        else if (Input.GetAxis("Fire2") == 0)
        {
            meleeSound = false;
        }

        //anim.SetFloat("Vertical", movement.y);
        //anim.SetFloat("Horizontal", movement.x);

        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);

        float angle = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg;

        shootingRotation = Quaternion.Euler(0, 0, angle - 90);

        gameObject.transform.Find("Gun").gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle < 90 && angle > -90)
        {
            gameObject.transform.Find("Gun").gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            gameObject.transform.Find("Gun").gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().flipY = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina > 0)
        {
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }

        if (running && !tired)
        {
            moveSpeedActual = moveSpeed + 10;
            stamina -= Time.deltaTime;
            if (stamina <= 0)
            {
                stamina = 0;
                moveSpeedActual = moveSpeed;
                tired = true;
            }
        }
        else
        {
            moveSpeedActual = moveSpeed;
            stamina += Time.deltaTime;
            if (stamina > 5)
            {
                tired = false;
                stamina = 5;
            }
        }

        if ((Input.GetAxis("Horizontal")) > 0)
            sr.flipX = false;
        else if ((Input.GetAxis("Horizontal") < 0))
            sr.flipX = true;

        // Debug.Log(stamina);
    }
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb2d.MovePosition(rb2d.position + (movement * moveSpeedActual * Time.deltaTime));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            gameManager.ManageHP(3);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ammo"))
        {
            gameManager.ManageAmmo(10);
            Destroy(collision.gameObject);
        }
    }
}
