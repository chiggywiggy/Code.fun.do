using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTriggerScript : MonoBehaviour {
	public AudioSource music;
	public AudioClip clip;
	public GameObject dead;
	public GameObject death;
	void Start ()
	{
		clip = music.clip;
	}
	void OnTriggerEnter(Collider collider){
		if(collider.tag=="Player"){
			death.SetActive(true);
			Destroy (collider.gameObject);
			music.Play ();
		}

		if(collider.tag=="Enemy"){
			
			Vector3 rot = new Vector3 (collider.transform.eulerAngles.x, collider.transform.eulerAngles.y, collider.transform.eulerAngles.z);
			dead.transform.eulerAngles=rot;
			Vector3 tra = new Vector3 (collider.transform.position.x,collider.transform.position.y,collider.transform.position.z);
			dead.transform.position=tra;
			Destroy(collider.gameObject);
			Instantiate (dead);
		

		
		}
	}

	
}
