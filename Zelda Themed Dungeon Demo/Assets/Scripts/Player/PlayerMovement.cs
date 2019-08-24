using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
	walk,
	attack,
	push
}

public class PlayerMovement : MonoBehaviour
{
	public PlayerState currentState;
	public float speed;
	public Rigidbody2D myRigidbody;
	public Vector3 change;
	private Animator animator;
	private Transform t;
	private Vector3 faceDirection;
	
	public GameObject pushBox;
	
	bool isPushing = false;
	
	bool gripped = false;
	
	
	private Vector3 lastDirection;
	
	[SerializeField]
	public Pause PauseObj;

	void Start()
	{
		currentState = PlayerState.walk;
		animator = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D>();
		animator.SetFloat("moveX", 0);
		animator.SetFloat("moveY", -1);
				
		t = GetComponent<Transform>();
	
	}

	void Update()
	{
		//MOVEMENT CONTROLS//----------------
		
		print("last" + lastDirection);
		
		print("face" + faceDirection);
		
		if (!isPushing && Time.timeScale > 0f)
		{
			change = Vector3.zero;
			change.x = Input.GetAxisRaw("Horizontal");
			change.y = Input.GetAxisRaw("Vertical");
			UpdateAnimationAndMove();
		}
		
		//RAYCAST//----------------
			
		faceDirection = GetFaceDirection(change, change);		
		
		RaycastHit2D hit = Physics2D.Raycast(t.position, lastDirection, 20f);
				
		Debug.DrawRay(t.position, lastDirection, Color.red, 0.1f);
		
		//PUSHING//-------------------
		if (gripped)
		{
			faceDirection = lastDirection;
		}
		
		if (!isPushing && Input.GetButton("Interact") && (hit.collider != null && hit.collider.tag == "pushable"))
		{
			gripped = true;

			animator.SetBool("pushing", true);
			
			currentState = PlayerState.push;
			
			Transform target = hit.collider.GetComponent<Transform>();
			
			t.position = target.position + (lastDirection * -1.6f);			
			
			if (gripped && (faceDirection == new Vector3(-1, 0, 0) && change.x < 0 || faceDirection == new Vector3(0, 1, 0) && change.y > 0 || faceDirection == new Vector3(1, 0, 0) && change.x > 0 || faceDirection == new Vector3(0, -1, 0) && change.y < 0))
			{	
				print("pushing");
				
				isPushing = true;

				StartCoroutine(PushCo(t.position, t.position + faceDirection, t, hit.collider.transform));
			}	
			
			if (gripped && (faceDirection == new Vector3(-1, 0, 0) && change.x > 0 || faceDirection == new Vector3(0, 1, 0) && change.y > 0 || faceDirection == new Vector3(1, 0, 0) && change.x < 0 || faceDirection == new Vector3(0, -1, 0) && change.y > 0))
			{	
				print("pulling");

				isPushing = true;

				StartCoroutine(PushCo(t.position, t.position + faceDirection, t, hit.collider.transform));
			}	
		}

		else if (!isPushing && currentState == PlayerState.push)
		{
			animator.SetBool("pushing", false);
			
			currentState = PlayerState.walk;
			
			gripped = false;
		}
		
		//ATTACKING//-------------------

		if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
		{
			StartCoroutine(AttackCo());
		}
		else if (currentState == PlayerState.walk)
		{
			UpdateAnimationAndMove();
		}
		
	}
	
	
//	[Header("PUSH COROUTINE")]

	IEnumerator PushCo(Vector2 origin, Vector2 dest, Transform t, Transform block)
	{		
		currentState = PlayerState.push;

		float maxTime = 1;

		float elapsedTime = 0;

		while (elapsedTime < maxTime)
		{
			animator.SetBool("pushing", true);
			currentState = PlayerState.push;

			t.position = Vector2.Lerp(origin, dest, (elapsedTime / maxTime));

			block.position = t.position + (faceDirection * 1.6f);

			yield return null;

			elapsedTime += Time.deltaTime;

		}

		yield return new WaitForSeconds(0.5f);

		isPushing = false;

	}
	
	
//	[Header("PULL COROUTINE")]

	IEnumerator PullCo(Vector2 origin, Vector2 dest, Transform t, Transform block)
	{		
		currentState = PlayerState.push;


		float maxTime = 1;

		float elapsedTime = 0;

		while (elapsedTime < maxTime)
		{
			animator.SetBool("pushing", true);
			currentState = PlayerState.push;

			t.position = Vector2.Lerp(origin, dest, (elapsedTime / maxTime));

			block.position = t.position + (faceDirection * 1.6f);

			yield return null;

			elapsedTime += Time.deltaTime;

		}

		yield return new WaitForSeconds(0.5f);

		isPushing = false;

	}
	
	
//	[Header("ATTACK COROUTINE")]
	
	private IEnumerator AttackCo()
	{
		animator.SetBool("attacking", true);
		currentState = PlayerState.attack;
		yield return null;
		animator.SetBool("attacking", false);
		yield return new WaitForSeconds(.25f);
		currentState = PlayerState.walk;
	}

	void UpdateAnimationAndMove()
	{
		if (change != Vector3.zero)
		{
			MoveCharacter();
			animator.SetFloat("moveX", change.x);
			animator.SetFloat("moveY", change.y);
			animator.SetBool("moving", true);
		}
		else
		{
			//canMove = false;
			animator.SetBool("moving", false);
		}
	}
	
	
//	[Header("MOVEMENT")]

	void MoveCharacter()
	{
		change.Normalize();
		myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);

	}
	

//	[Header("DIRECTION")]
	
	Vector3 GetFaceDirection(Vector3 currentDir, Vector3 input)
	{
		
		//print(currentDir);
		
		if (isPushing)
		{
			return currentDir;
		}
		
		if (currentDir.y == 0 && currentDir.x == 0)
		{			
			return currentDir;
		}		
		
		if (input.y > 0)
		{
			lastDirection = Vector2.up;
			return Vector2.up;
		}
		else if (input.y < 0)
		{
			lastDirection = -Vector2.up;
			return -Vector2.up;
		}
		else if (input.x > 0)
		{
			lastDirection = Vector2.right;
			return Vector2.right;
		}
		else
		{
			lastDirection = -Vector2.right;
			return -Vector2.right;
		}
	}
	
}
