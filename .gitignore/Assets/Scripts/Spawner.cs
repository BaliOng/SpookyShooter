using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public float MaxRadius = 2f;
	public float SkullInterval = 3f;
	public float GhostInterval = 5f;
	public float PumpkinInterval = 10f;
	public GameObject pumpkin = null;
	public GameObject ghost = null;
	public GameObject skull = null;
	public GameObject[] candy = new GameObject[3];
	private Transform Origin = null;
	public static bool candySpawned = false;
	
	//------------------------------
	void Awake()
	{
		Origin = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	//------------------------------
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("SpawnSkull", 0f, SkullInterval);
		InvokeRepeating("SpawnGhost", 0f, GhostInterval);
		InvokeRepeating("SpawnPumpkin", 0f, PumpkinInterval);
	}
	//------------------------------
	void FixedUpdate()
	{
		if(candySpawned == false)
			{
				SpawnCandy();
				candySpawned = true;
			}
	}
	void SpawnSkull () 
	{
		if(Origin == null)return;

		Vector3 SpawnPos = Origin.position + UnityEngine.Random.onUnitSphere * MaxRadius;
		SpawnPos = new Vector3(SpawnPos.x, 0f, -5f);
		Instantiate(skull, SpawnPos, Quaternion.identity);
	}
	void SpawnGhost () 
	{
		if(Origin == null)return;

		Vector3 SpawnPos = Origin.position + UnityEngine.Random.onUnitSphere * MaxRadius;
		SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
		Instantiate(ghost, SpawnPos, Quaternion.identity);
	}
	void SpawnPumpkin () 
	{
		if(Origin == null)return;

		Vector3 SpawnPos = Origin.position + UnityEngine.Random.onUnitSphere * MaxRadius;
		SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
		Instantiate(pumpkin, SpawnPos, Quaternion.identity);
	}
	void SpawnCandy ()
	{
		System.Random rnd = new System.Random();
		int candyType = rnd.Next(3);

		Vector3 SpawnPos = Origin.position + UnityEngine.Random.onUnitSphere * MaxRadius;
		SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
		Instantiate(candy[candyType], SpawnPos, Quaternion.identity);
	}
}
