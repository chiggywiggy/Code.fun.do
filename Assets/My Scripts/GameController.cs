﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

	Vector3 bombSpawn;
	float lastSpawnTime;
	float nextSpawnTime;
	
	public GameObject bomb;
	public float bombWaitTime;
	public GameObject player;
	public GameObject explosion;
	public int explosionSpread;
	public float explosionWaitTime;
	public float explosionStay;

	// Use this for initialization
	void Start(){
		lastSpawnTime=nextSpawnTime=0.0f;
	}
	
	void FixedUpdate(){
		bombSpawn = player.transform.position;
		bombSpawn += Vector3.up * 0.35f;
		
		if(Input.GetKeyDown(KeyCode.F) && Time.time > nextSpawnTime){
			//Debug.Log(Time.time);
			lastSpawnTime = Time.time;
			nextSpawnTime = lastSpawnTime + bombWaitTime;
			GameObject spawnedBomb = (GameObject)Instantiate(bomb, bombSpawn, player.transform.rotation);
			Destroy(spawnedBomb,3);
			StartCoroutine(explosionSpawn(bombSpawn, player.transform.rotation));	
			
		}

	}

	IEnumerator explosionSpawn(Vector3 bombSpawnCenter, Quaternion rotation){
		yield return new WaitForSeconds(3.0f);

		GameObject explosionCenter = (GameObject)Instantiate(explosion, bombSpawnCenter, rotation);
		Destroy(explosionCenter, explosionStay);
		yield return new WaitForSeconds(explosionWaitTime);

		for(int i=1; i<explosionSpread; i++){
			GameObject explosion1 = (GameObject)Instantiate(explosion, bombSpawnCenter + Vector3.forward *i, rotation);
			GameObject explosion2 = (GameObject)Instantiate(explosion, bombSpawnCenter + Vector3.back *i, rotation);
			GameObject explosion3 = (GameObject)Instantiate(explosion, bombSpawnCenter + Vector3.left*i, rotation);
			GameObject explosion4 = (GameObject)Instantiate(explosion, bombSpawnCenter + Vector3.right *i, rotation);
			DestroyExplosionObjects(explosion1, explosion2, explosion3, explosion4);
			yield return new WaitForSeconds(explosionWaitTime);
		}
	}

	void DestroyExplosionObjects(GameObject explosionObject1, GameObject explosionObject2, GameObject explosionObject3, GameObject explosionObject4){
		Destroy(explosionObject1, explosionStay);
		Destroy(explosionObject2, explosionStay);
		Destroy(explosionObject3, explosionStay);
		Destroy(explosionObject4, explosionStay);
	}

}
