using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public float Damage = 100f;
    public float LifeTime =2f;
    public Sprite livingAmmo;
    public Sprite deadAmmo;
    public GameObject spriteHolder;
 
	private SpriteRenderer spriteRenderer; 
    //public GameObject player;
    
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
        Health H = Col.gameObject.GetComponent<Health>();
        if(H == null) {return;}
        if((Col.gameObject.tag == "Pumpkin" || Col.gameObject.tag == "Skull") && PlayerController.skeleton == false){
			H.HealthPoints -= Damage;
		}
		if((Col.gameObject.tag == "Ghost" || Col.gameObject.tag == "Skull") && PlayerController.skeleton == true){
			H.HealthPoints -= Damage;
		}
        Die();
    }
    
    void Update()
    {
        if (PlayerController.skeleton == false)
            spriteRenderer.sprite = livingAmmo;
        if (PlayerController.skeleton == true)
            spriteRenderer.sprite = deadAmmo;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
