using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Windows.Kinect;

public class JointPositionOrientation : MonoBehaviour 
{
	protected Quaternion Rotation;
	protected float yScale = 0;
	public GameObject Head;

	public GameObject HandLeft;
	public GameObject HandRight;

	public float smoothMovement;
    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
	protected CameraSpacePoint pos;
	public float scale;
	public GameObject offsetNode; 

	// Use this for initialization
	void Start () 
    {

	}

	// Update is called once per frame
	void Update () 
    {
        if (_bodySourceManager == null)
        {
            return;
        }
        _bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();
        if (_bodyManager == null)
        {
            return;
        }
        Body[] data = _bodyManager.GetData();
        if (data == null)
        {
            return;
        }
        // get the first tracked body...
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
			{
				if(yScale == 10) {
					pos = body.Joints[JointType.Head].Position;
					float realPos = (float)(pos.Y*scale - transform.position.y);
					if(realPos > 5) {
						yScale = (float)(realPos - 5);
					}
					if(realPos < 5) {
						yScale = (float)(realPos + 5);
					}
				}
				pos = body.Joints[JointType.HandLeft].Position;
				HandLeft.transform.position = Vector3.Lerp(HandLeft.transform.position,new Vector3(pos.X*scale, pos.Y*scale-yScale, -1)-transform.position,Time.deltaTime*smoothMovement);

				pos = body.Joints[JointType.HandRight].Position;
				HandRight.transform.position = Vector3.Lerp(HandRight.transform.position,new Vector3(pos.X*scale, pos.Y*scale-yScale, -1)-transform.position,Time.deltaTime*smoothMovement);

				pos = body.Joints[JointType.Head].Position;
				Head.transform.position = Vector3.Lerp(Head.transform.position,new Vector3(pos.X*scale, pos.Y*scale-yScale, -1)-transform.position,Time.deltaTime*smoothMovement);



				Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,new Vector3((Head.transform.position.x-Camera.main.transform.position.x)/3, (Head.transform.position.y-Camera.main.transform.position.y)/3,Camera.main.transform.position.z),Time.deltaTime*smoothMovement);
				Camera.main.transform.LookAt(offsetNode.transform);
				//Head.transform.position = Vector3.Lerp(Head.transform.position,new Vector3(pos.X*scale, pos.Y*scale, -1)-transform.position,Time.deltaTime*smoothMovement);
				break;
            }
        }
	}


}
