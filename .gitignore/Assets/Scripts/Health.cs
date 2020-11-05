﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public GameObject DeathParticlesPrefab = null;
	private Transform ThisTransform = null;
	public bool ShouldDestroyOnDeath = true;
	//------------------------------
	void Start()
	{
		ThisTransform = GetComponent<Transform>();
	}
	//------------------------------
	public float HealthPoints
	{
		get
		{
			return _HealthPoints;
		}

		set
		{
			_HealthPoints = value;

			if(_HealthPoints <= 0)
			{
				
				SendMessage("Die", SendMessageOptions.DontRequireReceiver);

				if(DeathParticlesPrefab != null)
					Instantiate(DeathParticlesPrefab, ThisTransform.position, ThisTransform.rotation);
				if(ShouldDestroyOnDeath)Destroy(gameObject);
				if(gameObject.tag == "Player")
					GameController.GameOver();
			}
		}
	}
	//------------------------------
	[SerializeField]
	private float _HealthPoints = 100f;
}

