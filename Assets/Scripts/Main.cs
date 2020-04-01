using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public UnityEngine.UI.Text score;
	public UnityEngine.UI.Text GameTimer;
	public GameObject Katana;
	private Vector3 endpoint; 

	// Use this for initialization
	void Start () {
		CountDown();
	}

	void CountDown()
	{
		int curTime = int.Parse(GameTimer.text)-1;
		GameTimer.text = curTime.ToString ();
		if(curTime > 0) {
			Invoke("CountDown",1);
		}
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)) 
		{
			
			Ray ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
			endpoint = ray.GetPoint(15); 
			Debug.DrawRay(ray.origin, ray.direction * 15, Color.yellow);
			Katana.transform.position = Vector3.Lerp(Katana.transform.position,new Vector3(endpoint.x,endpoint.y,-1),Time.deltaTime*15);
		}
		if (Input.GetKey ("escape")) {
			Application.Quit();
		}
	}
}
