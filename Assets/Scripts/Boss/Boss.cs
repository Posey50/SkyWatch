using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private int hp = 200;

    public Animator boss;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("credits");
    }

    public void Credits()
    {
        boss.SetTrigger("death 0");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            hp -= 1;
            animator.SetTrigger("hit");
            Destroy(bullet.gameObject);
        }

        Pump pump = collision.GetComponent<Pump>();
        if (pump != null)
        {
            hp -= 2;
            animator.SetTrigger("hit");
            Destroy(pump.gameObject);
        }

        Bombe bombe = collision.GetComponent<Bombe>();
        if (bombe != null)
        {
            hp -= 5;
            animator.SetTrigger("hit"); 
        }

        BigBombe bigBombe = collision.GetComponent<BigBombe>();
        if (bigBombe != null)
        {
            hp -= 10;
            animator.SetTrigger("hit");
        }
    }

    
    IEnumerator Death()
    {
        Credits();

        yield return null;
    }
  
}
