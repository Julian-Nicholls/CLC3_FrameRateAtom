using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleonSpawner : MonoBehaviour {

	//public access to edit from editor
	public float timeBetweenSpawns;
	public float spawnDistance;
	public Nucleon[] nucleonPrefabs;

	float timeSinceLastSpawn;

	// Use this for initialization
	void Start () {

		//with V Sync disabled, this is to prevent hardware overuse
		Application.targetFrameRate = 70;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//time since last prefab was spawned
		timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

		//if enough time has elapsed, spawn prefab and reset time
		if (timeSinceLastSpawn >= timeBetweenSpawns) {
			timeSinceLastSpawn = timeSinceLastSpawn - timeBetweenSpawns;
			SpawnNucleon ();
		}
	}

	void SpawnNucleon(){

		//choose one of two prefabs, and place it a set distance from the centre
		Nucleon prefab = nucleonPrefabs [Random.Range (0, nucleonPrefabs.Length)];
		Nucleon spawn = Instantiate<Nucleon> (prefab);
		spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
	}
}
