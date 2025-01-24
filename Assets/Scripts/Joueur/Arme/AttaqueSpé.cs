using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueSpé : MonoBehaviour
{
    public GameObject bigBombe;

    public void AttaqueSpe()
    {
        GameObject go = Instantiate(bigBombe, transform.position, Quaternion.Euler(0, 0, 22.5f));
    }
}
