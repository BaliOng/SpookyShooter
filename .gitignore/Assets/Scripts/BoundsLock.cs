using UnityEngine;
using System.Collections;

public class BoundsLock : MonoBehaviour 
{
	//------------------------------
	public Rect levelBounds;
	private Transform ThisTransform = null;
	//------------------------------
	// Use this for initialization
	void Awake () 
	{

		ThisTransform = GetComponent<Transform>();
	}
	//------------------------------
	// Update is called once per frame
	void LateUpdate () 
	{
		//Clamp position
		ThisTransform.position = new Vector3(Mathf.Clamp(ThisTransform.position.x, levelBounds.xMin, levelBounds.xMax),
		                                     ThisTransform.position.y,
		                                     Mathf.Clamp(ThisTransform.position.z, levelBounds.yMin, levelBounds.yMax));
	}

	void OnDrawGizmosSelected()
	{
		const int cubeDepth = 1;
		Vector3 boundsCenter = new Vector3(levelBounds.xMin + levelBounds.width*0.5f, 0, levelBounds.yMin + levelBounds.height*0.5f);
		Vector3 boundsHeight = new Vector3 (levelBounds.width, cubeDepth, levelBounds.height);
		Gizmos.DrawWireCube(boundsCenter, boundsHeight);
	}

}