using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpackmove : MonoBehaviour {
    public float healthspeed = 3f;
    private GameObject boss;
    public float healdamage = 30f;
    public GameObject healsound;
    // Use this for initialization
    void Start () {
		
	}
    private void Awake()
    {
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.MoveTowards(transform.position, boss.transform.position, healthspeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        
            if (other.gameObject.tag == "Boss")
            {
                other.GetComponent<BossBehavior>().Health += healdamage;
            Instantiate(healsound, transform.position, transform.rotation);
            Destroy(gameObject);
            }

        
    }
    }
