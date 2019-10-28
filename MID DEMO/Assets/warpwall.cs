using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpwall : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Boss")||(other.gameObject.tag == "Player1")|| (other.gameObject.tag == "Player2"))
        {
            if (other.transform.position.x < 0)
            {
                other.transform.position = new Vector3(-other.transform.position.x-1f , other.transform.position.y, other.transform.position.z);
            }
            else if (other.transform.position.x > 0)
            {
                other.transform.position = new Vector3((other.transform.position.x*-1f)+1f, other.transform.position.y, other.transform.position.z);
            }
            }
    }
}
