using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interactable : MonoBehaviour 
{
	public GameObject dialogBox;
	public Text dialogText;
	public bool playerInRange;
	//[SerializeField]
	public Pause PauseObj;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerInRange = true;
			Debug.Log("Player in range");
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player left range");
			playerInRange = false;
		}
	}
}
