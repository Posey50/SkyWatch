using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour

{
    public float speed = 4f;
    private Vector3 StartPosition;
    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(translation:Vector3.left*speed*Time.deltaTime);
        if (transform.position.x < -20f)
        {
            transform.position = StartPosition;
        }
    }
}
