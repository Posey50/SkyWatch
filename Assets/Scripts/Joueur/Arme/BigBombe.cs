using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BigBombe : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0);
    public Vector2 velocity;
    public float speed = 2;

    private bool explosion = false;

    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        
        rb = GetComponent<Rigidbody2D>();

        direction = (transform.localRotation * Vector2.right).normalized;
    }

    void Update()
    {
        velocity = direction * speed;
    }
    private void FixedUpdate()
    {
        if (!explosion)
        {
            Vector2 pos = transform.position;

            pos += velocity * Time.fixedDeltaTime;

            transform.position = pos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Parallax parallax = collision.GetComponent<Parallax>();
        if (parallax != null)
        {
            explosion = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.46f);
        }

        MoveSoldat soldat = collision.GetComponent<MoveSoldat>();
        if (soldat != null)
        {
            explosion = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.46f);
        }

        Avion avion = collision.GetComponent<Avion>();
        if (avion != null)
        {
            explosion = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.46f);
        }

        Boss boss = collision.GetComponent<Boss>();
        if (boss != null)
        {
            explosion = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.46f);
        }
    }
}
