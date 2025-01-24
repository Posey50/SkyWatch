using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bombe : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Parallax parallax = collision.GetComponent<Parallax>();
        if (parallax != null)
        {
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.46f);
        }

        MoveSoldat soldat = collision.GetComponent<MoveSoldat>();
        if (soldat != null)
        {
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.46f);
        }

        Avion avion = collision.GetComponent<Avion>();
        if (avion != null)
        {
            Destroy(gameObject);
        }

        Boss boss = collision.GetComponent<Boss>();
        if (boss != null)
        {
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.46f);
        }
    }
}
