using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rupee : MonoBehaviour 
{
	public int rupeeValue;


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
			RupeeCount.rupeeCount += rupeeValue;
			
			this.gameObject.SetActive(false);
			
			Debug.Log("Player in range");
		}
	}
}
