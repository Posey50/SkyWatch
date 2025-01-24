using UnityEngine;

public class MoveSoldat : MonoBehaviour
{
    public bool boss = false;

    public float moveSpeed = 1f;
    private float place;
    private float  t;

    private Vector3 start;
    public LayerMask layer;

    public AnimationCurve acceleration;
    private Animator animator;

    public GameObject bullet;
    private float soldatRate = 4f;
    private float nextSoldatFire;

    [HideInInspector]
    public Spawner spawner;

    public int rangeMin;
    public int rangeMax;

    private PlayerController playerController;
    void Start()
    {
        place = Random.Range(rangeMin, rangeMax);
        t = 0;

        start = transform.position;

        animator = GetComponent<Animator>();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!boss)
        {
            var x = Mathf.Lerp(start.x, place, acceleration.Evaluate(t));
            var y = start.y;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 50f, 1 << layer);

            // If it hits something...
            if (hit.collider != null)
            {
                // Calculate the distance from the surface and the "error" relative
                // to the floating height.
                float distance = Mathf.Abs(hit.point.y - transform.position.y);
                y = hit.point.y - distance;
            }
            transform.position = new Vector3(x, y, start.z);
            t += Time.deltaTime / moveSpeed;

            if (transform.position.x == place)
            {
                animator.SetBool("isPlaced", true);
                if (transform.position.x == place && Time.time > nextSoldatFire)
                {
                    nextSoldatFire = Time.time + soldatRate;
                    SoldatFire();
                }
            }
        }
        else
        {
            var x = Mathf.Lerp(start.x, place, acceleration.Evaluate(t));
            var y = start.y;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 50f, 1 << layer);

            // If it hits something...
            if (hit.collider != null)
            {
                // Calculate the distance from the surface and the "error" relative
                // to the floating height.
                float distance = Mathf.Abs(hit.point.y - transform.position.y);
                y = hit.point.y - distance;
            }
            transform.position = new Vector3(x, y, start.z);
            t += Time.deltaTime / moveSpeed;

            if (transform.position.x == place)
            {
                animator.SetBool("isPlaced", true);
                if (transform.position.x == place && Time.time > nextSoldatFire)
                {
                    nextSoldatFire = Time.time + soldatRate;
                    SoldatFire();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bombe bombe = collision.GetComponent<Bombe>();
        if (bombe != null)
        {
            playerController.count++;
            playerController.change++;
            spawner.count -= 1;
            Destroy(gameObject);
        }

        BigBombe bigBombe = collision.GetComponent<BigBombe>();
        if (bigBombe != null)
        {
            playerController.count++;
            playerController.change++;
            spawner.count -= 1;
            Destroy(gameObject);
        }

        Pump pump = collision.GetComponent<Pump>();
        if (pump != null)
        {
            playerController.count++;
            playerController.change++;
            spawner.count -= 1;
            Destroy(gameObject);
            Destroy(pump.gameObject);
        }

        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            playerController.count++;
            playerController.change++;
            spawner.count -= 1;
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
    public void SoldatFire()
    {
        animator.SetTrigger("fire");
        GameObject go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 45));
    }
}
