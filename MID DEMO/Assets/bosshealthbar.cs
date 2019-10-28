using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosshealthbar : MonoBehaviour {
    private GameObject target;
	// Use this for initialization
	void Start () {
		target =GameObject.Find("血條");
	}
	
	// Update is called once per frame
	void Update () {

        target.transform.localScale= new Vector3((GetComponent<BossBehavior>().Health / 200)*10f,3f,1f);
	}
}
