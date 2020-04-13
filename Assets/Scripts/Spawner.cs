using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Melone;
	public GameObject Kiwi;
	public GameObject AppleRed;
    public GameObject AppleGreen;
    public GameObject Orange;
    public GameObject Strawberry;
    public GameObject Coconut;
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
		int i = Random.Range (0, 7);
		switch (i) {
		case 0:
			Instantiate(AppleRed, new Vector3(Random.Range(-5,5),-9,-1), Quaternion.identity); 
			break;
		case 1:
			Instantiate(Melone, new Vector3(Random.Range(-5,5),-9,-1), Quaternion.identity);
            break;
		case 2:
			Instantiate(Kiwi, new Vector3(Random.Range(-5,5),-9,-1), Quaternion.identity); 
			break;
        case 3:
            Instantiate(AppleGreen, new Vector3(Random.Range(-5, 5), -9, -1), Quaternion.identity);
            break;
        case 4:
            Instantiate(Orange, new Vector3(Random.Range(-5, 5), -9, -1), Quaternion.identity);
            break;
        case 5:
            Instantiate(Strawberry, new Vector3(Random.Range(-5, 5), -9, -1), Quaternion.identity);
            break;
        case 6:
            Instantiate(Coconut, new Vector3(Random.Range(-5, 5), -9, -1), Quaternion.identity);
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
