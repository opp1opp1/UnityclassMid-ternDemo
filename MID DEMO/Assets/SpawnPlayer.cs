using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public float spwantime = 1f;
    private float spwantimer;
    public GameObject player1;
    public GameObject player2;
    private float random;
    // Start is called before the first frame update
    void Start()
    {
        spwantimer = spwantime;
       
    }

    // Update is called once per frame
    void Update()
    {
        spwantimer -= Time.deltaTime;
        if (spwantimer <= 0f)
        {
            random = Random.Range(0, 100);
            if (random <= 90)
            {
                random = Random.Range(-8, 8);
                Vector3 spawnposition = transform.position;
                spawnposition.x += random;
                Instantiate(player1, spawnposition, transform.rotation);
                spwantimer = spwantime;
            }
            else if (random > 90)
            {
                random = Random.Range(-8, 8);
                Vector3 spawnposition = transform.position;
                spawnposition.x += random;
                Instantiate(player2, spawnposition, transform.rotation);
                spwantimer = spwantime;
            }
            
        }
    }
}
