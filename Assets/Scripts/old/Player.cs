using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
	private const string HORIZONTAL = "Horizontal";
	private const string VERTICAL = "Vertical";

	private Rigidbody2D _rb;
	private Animator _anim;

	[SerializeField] private float speed;

	private bool isControllable;
	private void Awake()
	{
		_anim = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		SetControl(true);
		StartCoroutine(MovementManagement());
		StartCoroutine(RotationManagement());
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	private IEnumerator MovementManagement()
	{
		while (true)
		{
			if (isControllable)
			{
				var timeSpeed = speed * Time.deltaTime;
				_rb.velocity = new Vector2(CheckInputX() * timeSpeed, CheckInputY() * timeSpeed);
			}
			yield return new WaitForFixedUpdate();
		}

	}
	private IEnumerator RotationManagement()
	{
		var originalScale = transform.localScale;
		while (true)
		{
			if (Mathf.Abs(_rb.velocity.x) > 0.001f) transform.localScale = new Vector2(Mathf.Abs(originalScale.x) * (_rb.velocity.x > 0? 1: -1), originalScale.y);
			yield return null;
		}

	}

	private float CheckInputX()
	{
		return Input.GetAxisRaw(HORIZONTAL);
	}

	private float CheckInputY()
	{
		return Input.GetAxisRaw(VERTICAL);
	}

	public void SetControl(bool toControl)
	{
		isControllable = toControl;
	}

}
