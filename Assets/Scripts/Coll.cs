using UnityEngine;
using System.Collections;

public class Coll : MonoBehaviour
{
	/*public Transform SplatterCitrus;
	public Transform SplatterApple;	
	public Transform CitrusSlice;
    public Transform AppleSlice;*/


    public Transform SplatterMellon;
	public Transform MelonSlice;

    public Transform SplatterCoconut;
    public Transform CoconutSlice;

    public Transform SplatterStrawberry;
    public Transform StrawberrySlice;

    public Transform SplatterOrange;
    public Transform OrangeSlice;

    public Transform SplatterKiwi;
    public Transform KiwiSlice;

    public Transform SplatterApple; // one splatter for any apple
    public Transform GreenAppleSlice;
    public Transform RedAppleSlice;


    public float SliceForceKoef =1;

    public AudioClip splatSound;
	public UnityEngine.UI.Text score;
	private Transform slice1;
    private Transform slice2;
    private Transform splat;

    void OnCollisionEnter(Collision col)
	{
		GameObject SliceHit;
		SliceHit = col.gameObject;
		if (SliceHit.tag == "Fruit")
		{
			var scr = int.Parse(score.text) + 1;
			score.text = scr.ToString();
			GetComponent<AudioSource>().PlayOneShot(splatSound);
			//get the speed and rotation and than destroy the fruit
			var VelocityF = SliceHit.transform.GetComponent<Rigidbody>().velocity;
			var AngularVelocityF = SliceHit.transform.GetComponent<Rigidbody>().angularVelocity;

            switch (SliceHit.name)
            {

                case "WaterMelon(Clone)":
                    slice1 = Instantiate(MelonSlice, SliceHit.transform.position, Quaternion.identity);
                    slice2 = Instantiate(MelonSlice, SliceHit.transform.position, Quaternion.Euler(0, 180, 0));
                    if(SplatterMellon!=null)
                        splat = Instantiate(SplatterMellon, SliceHit.transform.position + (new Vector3(0, 0, 1)), Quaternion.Euler(0, 180, Random.Range(0, 360)));
                    break;

                case "Coconut(Clone)":
                    slice1 = Instantiate(CoconutSlice, SliceHit.transform.position, Quaternion.identity);
                    slice2 = Instantiate(CoconutSlice, SliceHit.transform.position, Quaternion.Euler(0, 180, 0));
                    if (SplatterCoconut != null)
                        splat = Instantiate(SplatterCoconut, SliceHit.transform.position + (new Vector3(0, 0, 1)), Quaternion.Euler(0, 180, Random.Range(0, 360)));

                    break;


                case "Orange(Clone)":
                    slice1 = Instantiate(OrangeSlice, SliceHit.transform.position, Quaternion.identity);
                    slice2 = Instantiate(OrangeSlice, SliceHit.transform.position, Quaternion.Euler(0, 180, 0));
                    if (SplatterOrange != null)
                        splat = Instantiate(SplatterOrange, SliceHit.transform.position + (new Vector3(0, 0, 1)), Quaternion.Euler(0, 180, Random.Range(0, 360)));
                    break;

                case "Kiwi(Clone)":
                    slice1 = Instantiate(KiwiSlice, SliceHit.transform.position, Quaternion.identity);
                    slice2 = Instantiate(KiwiSlice, SliceHit.transform.position, Quaternion.Euler(0, 180, 0));
                    if (SplatterKiwi != null)
                        splat = Instantiate(SplatterKiwi, SliceHit.transform.position + (new Vector3(0, 0, 1)), Quaternion.Euler(0, 180, Random.Range(0, 360)));
                    break;

                case "GreenApple(Clone)":
                    slice1 = Instantiate(GreenAppleSlice, SliceHit.transform.position, Quaternion.identity);
                    slice2 = Instantiate(GreenAppleSlice, SliceHit.transform.position, Quaternion.Euler(0, 180, 0));
                    if (SplatterApple != null)
                        splat = Instantiate(SplatterApple, SliceHit.transform.position + (new Vector3(0, 0, 1)), Quaternion.Euler(0, 180, Random.Range(0, 360)));
                    break;

                case "RedApple(Clone)":
                    slice1 = Instantiate(RedAppleSlice, SliceHit.transform.position, Quaternion.identity);
                    slice2 = Instantiate(RedAppleSlice, SliceHit.transform.position, Quaternion.Euler(0, 180, 0));
                    if (SplatterApple != null)
                        splat = Instantiate(SplatterApple, SliceHit.transform.position + (new Vector3(0, 0, 1)), Quaternion.Euler(0, 180, Random.Range(0, 360)));
                    break;

                case "Strawberry(Clone)":
                    slice1 = Instantiate(StrawberrySlice, SliceHit.transform.position, Quaternion.identity);
                    slice2 = Instantiate(StrawberrySlice, SliceHit.transform.position, Quaternion.Euler(0, 180, 0));
                    if (SplatterStrawberry != null)
                        splat = Instantiate(SplatterStrawberry, SliceHit.transform.position + (new Vector3(0, 0, 1)), Quaternion.Euler(0, 180, Random.Range(0, 360)));
                    break;

				default:
                    break;



            }

			/*if (SliceHit.name == "Citrus(Clone)")

			{
				slice1 = Instantiate(CitrusSlice, SliceHit.transform.position, Quaternion.identity);
				slice2 = Instantiate(CitrusSlice, SliceHit.transform.position, Quaternion.Euler(0, 180, 0));
				splat = Instantiate(SplatterCitrus, SliceHit.transform.position + (new Vector3(0, 0, 1)), Quaternion.Euler(0, 180, Random.Range(0, 360)));
			}

			if (SliceHit.name == "Melon(Clone)"|| SliceHit.name == "WaterMellonHD(Clone)")
			{

				slice1 = Instantiate(MelonSlice, SliceHit.transform.position, Quaternion.identity);
				slice2 = Instantiate(MelonSlice, SliceHit.transform.position, Quaternion.Euler(0, 180, 0));
				splat = Instantiate(SplatterMellon, SliceHit.transform.position +(new Vector3(0, 0, 1)), Quaternion.Euler(0, 180, Random.Range(0, 360)));
			}

			if (SliceHit.name == "Apple(Clone)")
			{
				slice1 = Instantiate(AppleSlice, SliceHit.transform.position, Quaternion.identity);
				slice2 = Instantiate(AppleSlice, SliceHit.transform.position, Quaternion.Euler(0, 180, 0));
				splat = Instantiate(SplatterApple, SliceHit.transform.position + (new Vector3(0, 0, 1)), Quaternion.Euler(0, 180, Random.Range(0, 360)));
			}*/
            if (slice1 != null && slice2 != null)
            {
                slice1.GetComponent<Rigidbody>().velocity = VelocityF;
                slice1.GetComponent<Rigidbody>().angularVelocity = AngularVelocityF;
                //add force so it wont stay with slice 2
                slice1.GetComponent<Rigidbody>().AddForce(new Vector3(-100*SliceForceKoef, 0, 0));
                slice2.GetComponent<Rigidbody>().velocity = VelocityF;
                slice2.GetComponent<Rigidbody>().angularVelocity = AngularVelocityF;
                //add force so it wont stay with slice 1
                slice2.GetComponent<Rigidbody>().AddForce(new Vector3(100*SliceForceKoef, 0, 0));

                Destroy(slice2.gameObject, 3);
                Destroy(slice1.gameObject, 3);
            }

            if (splat != null) Destroy(splat.gameObject, 3);
            Destroy(SliceHit);
            slice1 = slice2 = splat = null;
        }
	}

	void Update()
	{

	}
}
