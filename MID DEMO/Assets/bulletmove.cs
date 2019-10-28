using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmove : MonoBehaviour {
    public float bulletspeed = 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag != "player2_bullet")
        {
            transform.Translate(Vector3.up * Time.deltaTime * -bulletspeed);
        }
        else
        transform.Translate( Vector3.down*Time.deltaTime * -bulletspeed);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
           
            Destroy(gameObject);
        }
    }

}
