using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed = 3.0f;
    private bool isGrounded;
    private Vector3 direction;
   
    private void Start()
    {
        direction = transform.right;
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {
        Move();
        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        isGrounded = colliders.Length > 1;
    }
    private void Move()
    {
        if (isGrounded)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position+transform.up*0.5f+transform.right*direction.x*0.7f,0.1f);
            if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())) direction *= -1.0f;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        }
        else
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            unit.ReceiveDamage();
        }
    }

}
