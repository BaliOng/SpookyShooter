using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------
public class PlayerController : MonoBehaviour
{
	//------------------------------
	private Rigidbody ThisBody = null;
	private Transform ThisTransform = null;
	
	public bool MouseLook = true;
	public string HorzAxis = "Horizontal";
	public string VertAxis = "Vertical";
	public string FireAxis = "Fire1";
	public string ModeAxis = "Fire2";
	public float MaxSpeed = 5f;
	public float ReloadDelay = 0.3f;
	public bool CanFire = true;
	public Transform[] TurretTransforms;

	public Sprite defaultsprite; // Drag your first sprite here
	public Sprite skeletonsprite; // Drag your second sprite here
	public static bool skeleton = false;
	public GameObject spriteHolder;
 
	private SpriteRenderer spriteRenderer; 
	//------------------------------
	// Use this for initialization
	void Awake ()
	{
		ThisBody = GetComponent<Rigidbody>();
		ThisTransform = GetComponent<Transform>();
		spriteRenderer = spriteHolder.GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
     if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
        spriteRenderer.sprite = defaultsprite; // set the sprite to sprite1
	}
	//------------------------------
	// Update is called once per frame
	void Update ()
	{
		//Update movement
		float Horz = Input.GetAxis(HorzAxis);
		float Vert = Input.GetAxis(VertAxis);
		Vector3 MoveDirection = new Vector3(Horz, 0.0f, Vert);
		ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);
		
		//Clamp speed
		ThisBody.velocity = new Vector3(Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed),
		                                Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed),
		                                Mathf.Clamp(ThisBody.velocity.z, -MaxSpeed, MaxSpeed));
		
		//Should look with mouse?
		if(MouseLook)
		{
			//Update rotation - turn to face mouse pointer
			Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
			MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);
			
			//Get direction to cursor
			Vector3 LookDirection = MousePosWorld - ThisTransform.position;
			
			//FixedUpdate rotation
			ThisTransform.localRotation = Quaternion.LookRotation(LookDirection.normalized,Vector3.up);
		}

		if(Input.GetButtonDown(FireAxis) && CanFire)
			{
				foreach(Transform T in TurretTransforms)
				{
					AmmoManager.SpawnAmmo(T.position, T.rotation);
					Debug.Log("Ammo fired");
				}
				CanFire = false;
				Invoke("EnableFire", ReloadDelay);
			}
		if(Input.GetButtonDown(ModeAxis))
			ChangeModes();
		}
	void EnableFire()
	{
		CanFire = true;
	}

	void ChangeModes()
	{
		if (skeleton == false){
			spriteRenderer.sprite = skeletonsprite;
			skeleton = true;
			}
		else
		{
			spriteRenderer.sprite = defaultsprite;
			skeleton = false;
			}
		Debug.Log("Mode change");
	}
}