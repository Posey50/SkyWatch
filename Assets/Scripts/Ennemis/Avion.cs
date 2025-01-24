using UnityEngine;

public class Avion : MonoBehaviour
{
    private float moveSpeed = 5.8f;

    private bool canBeDestroyed = false;
    private Animator animator;

    private PlayerController playerController;

    void Start()
    {
        animator = GetComponent<Animator>();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (transform.position.x < 7.6f)
        {
            canBeDestroyed = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;

        if (pos.x < -11.5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            playerController.count++;
            playerController.change++;
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.40f);
            Destroy(bullet.gameObject);
        }

        Pump pump = collision.GetComponent<Pump>();
        if (pump != null)
        {
            playerController.count++;
            playerController.change++;
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.40f);
            Destroy(pump.gameObject);
        }

        Bombe bombe = collision.GetComponent<Bombe>();
        if (bombe != null)
        {
            playerController.count++;
            playerController.change++;
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.40f);
        }

        BigBombe bigBombe = collision.GetComponent<BigBombe>();
        if (bigBombe != null)
        {
            playerController.count++;
            playerController.change++;
            Destroy(gameObject, 0.40f);
        }
    }
}
