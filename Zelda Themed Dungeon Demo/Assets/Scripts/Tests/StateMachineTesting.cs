using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineTesting : MonoBehaviour
{
	enum GameState
	{
		Paused,
		PausedForDuration,
		Running
	}
	
	GameState currentState;
	
	float lastStateChange = 0.0f;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
