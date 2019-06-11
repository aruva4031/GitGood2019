using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 300);

		if (gameObject.name.Contains("(Clone)")){
				Object.Destroy(this.gameObject, 2.0f);
		}
	}
}
