using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
	key,
	enemy,
	button
}

//change "Push" input to "Interact" for all things that use

public class Door : Interactable 
{
	[Header("Door Variables")]
	public DoorType thisDoorType;
	public bool open = false;
	
	private void Update()
	{
		if (Input.GetKeyDown("Interact"))
		{
			if (playerInRange)
			{
				//does the player have a key?
				//if so then call the open method
			}
		}
	}
	
	public void Open()
	{
		//turn off the doors sprite renderer
		//set the open to true
		//turn off the doors box collider
	}
	
	public void Close()
	{
		
	}

}
