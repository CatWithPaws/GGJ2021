using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{

	public enum PlayerState
	{
		Idle,Walk
	}
	public enum Masks
	{

	}
	private const string HORIZONTAL = "Horizontal";
	private const string VERTICAL = "Vertical";

	private Rigidbody2D playerRB;
	private Animator playerAnim;


	[SerializeField] private float speed;
	[SerializeField] private Vector2 velocity;


	private void Awake()
	{
		playerAnim = GetComponent<Animator>();
		playerRB = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		
	}

	private void Update()
	{
		CheckInput();



		playerRB.velocity = velocity;
	}

	private void CheckInput()
	{
		velocity.x = Input.GetAxisRaw(HORIZONTAL);
		velocity.y = Input.GetAxisRaw(VERTICAL);
		velocity *= speed;
	}

}
