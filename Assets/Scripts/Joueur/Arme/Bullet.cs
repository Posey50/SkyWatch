using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0);
    public Vector2 velocity;
    public float speed = 2;

    void Start()
    {
        direction = (transform.localRotation * Vector2.right).normalized;
    }

    void Update()
    {
        velocity = direction * speed;
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate() 
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }
}