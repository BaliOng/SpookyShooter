using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPickup : MonoBehaviour
{
	//------------------------------
	void OnTriggerStay(Collider Col)
	{
		Health H = Col.gameObject.GetComponent<Health>();

		if(Col.gameObject.tag == "Player" && H.HealthPoints < 100){
			Destroy(gameObject);
			Spawner.candySpawned = false;
			if(H.HealthPoints > 95)
				H.HealthPoints = 100;
			else
				H.HealthPoints += 5;
			Debug.Log("heal pickup");
			}
	}
}
