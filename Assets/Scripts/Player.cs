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
		Owl,Monkey,Tiger,None
	}
	private const string HORIZONTAL = "Horizontal";
	private const string VERTICAL = "Vertical";

	private Rigidbody2D playerRB;
	private Animator playerAnim;

	public static Player Instance;

	[SerializeField] private float speed;
	[SerializeField] private Vector2 velocity;

	bool[] ingridientInventory = new bool[5];

	bool isIngridientQuestCompleted => ingridientInventory[0] && ingridientInventory[1] && ingridientInventory[2] && ingridientInventory[3] && ingridientInventory[4];

	Masks playerMask = Masks.Monkey;

	public bool isInDialog = false;
	private PlayerState playerState = PlayerState.Idle;
	private void Awake()
	{
		playerAnim = GetComponent<Animator>();
		playerRB = GetComponent<Rigidbody2D>();
		Instance = this;
	}
	
	public void PickIngridient(int ID)
	{
		ingridientInventory[ID] = true;
	}
	
	public void CompleteWizardQuest()
	{
		ingridientInventory = new bool[5];
	}

	private void Start()
	{
		
	}

	private void Update()
	{
		if (isInDialog) return;
		CheckInput();
		string animationName = "";
		if (velocity.x != 0)
		{
			playerState = PlayerState.Walk;
			animationName += "Move";
		}
		else
		{
			playerState = PlayerState.Idle;
			animationName += "Idle";
		}
		switch (playerMask)
		{
			case Masks.Tiger:
				animationName += "Tiger";
				break;
			case Masks.Monkey:
				animationName += "Monkey";
				break;
			case Masks.Owl:
				animationName += "Owl";
				break;
			case Masks.None:
				animationName += "NoneMask";
				break;
		}

		if(playerState != PlayerState.Idle)
		{
			if (transform.localScale.x > 0)
			{
				animationName += "Right";
			}
			else if (transform.localScale.x < 0)
			{
				animationName += "Left";
			}
		}

		if(velocity.y > 0)
		{
			animationName += "Up";
		}
		else if(velocity.y <= 0)
		{
			animationName += "Down";
		}

		print(animationName);


		playerAnim.Play(animationName);
		playerRB.velocity = velocity;
	}

	private void CheckInput()
	{
		velocity.x = Input.GetAxisRaw(HORIZONTAL);
		velocity.y = Input.GetAxisRaw(VERTICAL);
		
		velocity *= speed;
	}

}
