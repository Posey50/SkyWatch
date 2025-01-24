using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soute : MonoBehaviour
{
    public GameObject bombe;

    private bool drop;
    private float bombeRate = 1f;
    private float nextBombe;

    Vector2 direction;

    void Start()
    {
        
    }

    void Update()
    {
        drop = Input.GetKeyDown(KeyCode.Space);

        if (drop && Time.time > nextBombe)
        {
            drop = false;
            nextBombe = Time.time + bombeRate;
            Larguage();
        }
    }

    public void Larguage()
    {
        GameObject go = Instantiate(bombe, transform.position, Quaternion.Euler(0, 0, 0));
    }
}
