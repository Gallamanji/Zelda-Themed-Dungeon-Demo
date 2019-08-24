using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseTester : MonoBehaviour 
{
	public bool playerInRange;
	
	[SerializeField]
	private Pause PauseObj;

	void Update () 
	{
		//PauseObj.CheckPause();

		
		

		//Debug.Log(Time.realtimeSinceStartup);

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerInRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player left range");
		}
	}


}
