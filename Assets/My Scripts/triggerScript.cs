using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour {
	public AudioSource music;
	public AudioClip clip;
	public GameObject death;
	void start ()
	{
		death.SetActive (false);
		clip = music.clip;
	}
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			death.SetActive(true);
			Destroy (collider.gameObject);
			music.Play ();
		}
	}
}
