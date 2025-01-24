using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAvionSin : MonoBehaviour
{
    float sinCenterY;
    public Avion avion;

    void Start()
    {
        sinCenterY = transform.position.y;
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x) / 4;

        pos.y = sinCenterY + sin;

        transform.position = pos;
    }
}
