using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
   public float DamageRate = 10f;
	//------------------------------
	void OnTriggerStay(Collider Col)
	{
		Health H = Col.gameObject.GetComponent<Health>();

		if(H == null)return;

		if(Col.gameObject.tag == "Player"){
			H.HealthPoints -= DamageRate * Time.deltaTime;

			Debug.Log("taking damage");
			}
	}
}
