using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour 
{
	public Vector2 cameraChangeMax;
	public Vector2 cameraChangeMin;
	public Vector3 playerChange;
	private CameraMovement cam;
	GameObject Player;
	public bool playerInRange;

	
	[SerializeField]
	private Pause PauseObj;





	// Use this for initialization
	void Start () 
	{
		cam = Camera.main.GetComponent<CameraMovement>();

	}

	
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
//			cam.smoothing = cam.smoothing / 2;
//			StartCoroutine(CamSmoothing());
			cam.minPosition = cameraChangeMin;
			cam.maxPosition = cameraChangeMax;			
			other.transform.position += playerChange;

		}

	}
	
//	IEnumerator CamSmoothing()
//	{
//		
//		yield return new WaitForSeconds(2);
//		cam.smoothing = cam.smoothing * 2;
//	}

	


	

}