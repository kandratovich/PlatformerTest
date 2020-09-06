using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
   
    public int lives = 3;
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 5) lives=value;
            livesBar.Refresh();
        }
    }

    public int coin = 0;

    private LivesBar livesBar;

    public float speed = 4.0f;
    public float jumpforce = 7.0f;
    public Rigidbody2D PlayerRigidbody;
    public Animator charAnimator;
    public SpriteRenderer sprite;
    public GameObject GameOver;
    private bool isGrounded;
    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        charAnimator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        lives = CharacterStats.lives;
        livesBar.Refresh();
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal")) Move();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
        if (!Input.anyKey) charAnimator.SetInteger("State", 0);
        if (transform.position.y < -10.0f) Crashed();
    }
    void Jump()
    {
        PlayerRigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        charAnimator.SetInteger("State", 2);
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = colliders.Length > 1;
    }
    void Move()
    {
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
        charAnimator.SetInteger("State", 1);
        sprite.flipX = tempvector.x < 0.0f;
    }
    public override void ReceiveDamage()
    {
        Lives--;
        if (Lives > 0)
        {
            PlayerRigidbody.velocity = Vector3.zero;
            PlayerRigidbody.AddForce(transform.up * 5.0f, ForceMode2D.Impulse);
        }
        else Die();
    }

    public override void Die()
    {
        GameOver.SetActive(true);        
        Time.timeScale = 0f;
    }
    public void Crashed()
    {
        ReceiveDamage();
        transform.position = new Vector3(-6, -1, 89);
    }
}
