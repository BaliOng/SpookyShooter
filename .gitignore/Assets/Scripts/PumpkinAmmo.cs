using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinAmmo : MonoBehaviour
{
    public float Damage = 20f;
    public float LifeTime =2f;
    public Sprite pumpkinAmmo;
    public GameObject spriteHolder;
	private SpriteRenderer spriteRenderer; 
    public GameObject pumpkin;
    
   void Awake()
   {
        spriteRenderer = spriteHolder.GetComponent<SpriteRenderer>();
   }
 
    void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LifeTime);
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Pumpkin")
            return;
        Health H = Col.gameObject.GetComponent<Health>();
        if(H == null) {return;}
        if(Col.gameObject.tag == "Player"){
			H.HealthPoints -= Damage;
		}
        Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

