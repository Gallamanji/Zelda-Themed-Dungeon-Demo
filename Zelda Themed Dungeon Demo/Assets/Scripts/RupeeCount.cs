using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RupeeCount : MonoBehaviour 
{
	public static int rupeeCount = 0;
	Text rupees;

	// Use this for initialization
	void Start () 
	{
		rupees = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		rupees.text = "" + rupeeCount;
		
	}
}
