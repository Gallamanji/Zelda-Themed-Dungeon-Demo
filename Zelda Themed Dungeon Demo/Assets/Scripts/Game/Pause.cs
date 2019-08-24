using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	private bool paused;
	public float duration;
	public float pauseUntil;
	[SerializeField]
	public Pause PauseObj;

	public bool Paused
	{
		get
		{ 
			return paused; 
		}
		set
		{ 
			paused = value;

		}
		
	}

	
	public void PauseGame()
	{
		Time.timeScale = 0.0f;
		
	}
	
	public void UnPauseGame()
	{
		Time.timeScale = 1.0f;

	}
	





}

