using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //if (GetComponent<Rigidbody>().isKinematic == true) GetComponent<Rigidbody>().isKinematic = false; // обьект спавна изначально должен быть кинематик иначе получаются большие проблемы со спавном
		GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-6f,6f),Random.Range(-6f,6f),Random.Range(-6f,6f));
		GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-0.5f,0.5f),Random.Range(1f,1.5f),0f));
		//Destroy the fruit so we dont fill up our memory
		if (name.Contains("Clone")) {
			Destroy (gameObject, 10);
		}
	}
}
