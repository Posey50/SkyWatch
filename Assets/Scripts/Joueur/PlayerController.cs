using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float startSpeed = 1f;
    private bool isPlayable = false;

    public float maxPosX;
    public float minPosX;
    public float maxPosY;
    public float minPosY;

    bool changeLvl;

    Transform myTransform;

    public PlayerController playerController;

    private Animator animator;
    public Animator gameoversysteme;

    public int count = 0;
    public int change = 0;

    void Start()
    {
        myTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isPlayable)
        {
            Vector2 pos = transform.position;

            pos.x += Time.fixedDeltaTime * startSpeed;

            transform.position = pos;

            if (pos.x >= -5)
            {
                isPlayable = true;
            }
        }

        if (isPlayable)
        {
            float posX = Input.GetAxis("Horizontal");
            float posY = Input.GetAxis("Vertical");
            Vector3 newPos = new Vector3(posX, posY, 0) * Time.deltaTime * speed;
            myTransform.Translate(newPos);

            myTransform.position = new Vector3(Mathf.Clamp(myTransform.position.x, minPosX, maxPosX), myTransform.position.y, myTransform.position.z);
            myTransform.position = new Vector3(myTransform.position.x, Mathf.Clamp(myTransform.position.y, minPosY, maxPosY), myTransform.position.z);

            changeLvl = Input.GetKeyDown(KeyCode.Return);

            if (changeLvl)
            {
                SceneManager.LoadScene("Lvl 2");
            }
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("menu");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Avion avion = collision.GetComponent<Avion>();
        if (avion != null)
        {
            animator.SetBool("explosion", true);
            Destroy(gameObject, 1f);
            Destroy(avion.gameObject);
            gameoversysteme.SetTrigger("gameover");
        }

        SoldatBullet soldatBullet = collision.GetComponent<SoldatBullet>();
        if (soldatBullet != null)
        {
            animator.SetBool("explosion", true);
            Destroy(gameObject, 1f);
            Destroy(soldatBullet.gameObject);
            gameoversysteme.SetTrigger("gameover");
        }

        Cannon cannon = collision.GetComponent<Cannon>();
        if (cannon!= null)
        {
            animator.SetBool("explosion", true);
            Destroy(gameObject, 1f);
            Destroy(cannon.gameObject);
            gameoversysteme.SetTrigger("gameover");
        }
    }
}