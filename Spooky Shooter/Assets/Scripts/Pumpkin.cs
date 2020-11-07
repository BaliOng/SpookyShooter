using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    public Transform[] TurretTransforms;
    public float ReloadDelay = 2f;
	public bool CanFire = true;

    void Update()
    {
        if(CanFire && TurretTransforms != null){
        foreach(Transform T in TurretTransforms)
				{
					PumpkinManager.SpawnAmmo(T.position, T.rotation);
					Debug.Log("Pumpkin ammo fired");
				}
        CanFire = false;
	    Invoke("EnableFire", ReloadDelay);
        }
    }
    void EnableFire()
	{
		CanFire = true;
	}
}
