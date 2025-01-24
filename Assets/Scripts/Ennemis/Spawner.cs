using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ennemi;

    private float spawnRateAvion;
    private float nextSpawnAvion;
    public float nextSpawnMin;
    public float nextSpawnMax;

    private float nextSpawnSoldat;
    public bool isCountable;
    public int count = 0;

    void Start()
    {
        nextSpawnAvion = Time.time + Random.Range(nextSpawnMin, nextSpawnMax);
        nextSpawnSoldat = Time.time + Random.Range(nextSpawnMin, nextSpawnMax);
    }

    void Update()
    {
        spawnRateAvion = Random.Range(nextSpawnMin, nextSpawnMax);

        if (isCountable)
        {
            if (Time.time > nextSpawnSoldat && count < 10)
            {
                nextSpawnSoldat = Time.time + spawnRateAvion;
                Spawn();
                count += 1;
            }
        }
        else if (Time.time > nextSpawnAvion)
        {
            nextSpawnAvion = Time.time + spawnRateAvion;
            Spawn();
            count += 1;
        }
    }

    public void Spawn()
    {
        GameObject go = Instantiate(ennemi, transform.position, Quaternion.Euler(0, 0, 0));
        var soldat = go.GetComponent<MoveSoldat>();
        if(soldat != null)
        {
            soldat.spawner = this;
        }
    }
}