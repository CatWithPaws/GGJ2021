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

	public static Player Instance;

	[SerializeField] private float speed;
	[SerializeField] private Vector2 velocity;

	public bool isInDialog = false;
	private void Awake()
	{
		playerAnim = GetComponent<Animator>();
		playerRB = GetComponent<Rigidbody2D>();
		Instance = this;
	}

	private void Start()
	{
		
	}

	private void Update()
	{
		if (isInDialog) return;
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
