using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Melone;
	public GameObject Lemon;
	public GameObject Apple;
	public AudioClip spawnSound;
	protected int spawned;

	// Use this for initialization
	void Start () {
		Invoke("Spawn",3);
		spawned = 0;
	}
	
	// Update is called once per frame
	void Cooldown () {
		spawned -= 1;
	}

	void Spawn()
	{
		GetComponent<AudioSource>().PlayOneShot(spawnSound);
		int i = Random.Range (0, 3);
		switch (i) {
		case 0:
			Instantiate(Apple, new Vector3(Random.Range(-5,5),-9,-1), Quaternion.identity); 
			break;
		case 1:
			Instantiate(Melone, new Vector3(Random.Range(-5,5),-9,-1), Quaternion.identity); 
			break;
		case 2:
			Instantiate(Lemon, new Vector3(Random.Range(-5,5),-9,-1), Quaternion.identity); 
			break;
		}

		if (spawned > 7) {
			Invoke("Cooldown",0.5f);
		} else {
			SpawnStrategy ();
		}
	}

	void SpawnStrategy()
	{
		spawned += 1;
		int i = Random.Range (0, 4);
		switch (i) {
		case 0:
			Invoke("Spawn",2);Invoke("Spawn",3);Invoke("Spawn",4);
			break;
		case 1:
			Invoke("Spawn",3);Invoke("Spawn",2);
			break;
		case 2:
			Invoke("Spawn",5);
			break;
		case 3:
			Invoke("Spawn",7);
			break;
		}
	}
}
