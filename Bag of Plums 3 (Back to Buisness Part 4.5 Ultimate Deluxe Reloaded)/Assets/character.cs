using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {
	CharacterController characterController;

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public GameObject plum;
	private Vector3 moveDirection = Vector3.zero;

	void Start()
	{
		
		characterController = GetComponent<CharacterController>();

	}

	void Update()
	{
		transform.Rotate(0.0f, Input.GetAxis ("Horizontal") * speed, 0.0f);
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			GameObject bullet = Instantiate(plum, transform.position+(transform.forward), Quaternion.identity) as GameObject;
			bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 300);
			bullet.transform.forward = new Vector3(this.gameObject.transform.forward.x, bullet.transform.forward.y, this.gameObject.transform.forward.z);
			characterController.Move(new Vector3(-transform.forward.x*80*Time.deltaTime, 0.0f, -transform.forward.z*80*Time.deltaTime));
		}

		if (characterController.isGrounded)
		{
			// We are grounded, so recalculate
			// move direction directly from axes
			if (Input.GetKey (KeyCode.W)) {
				transform.position += transform.forward * Time.deltaTime * speed;
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.position -= transform.forward * Time.deltaTime * speed;
			}



			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}

		// Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
		// when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
		// as an acceleration (ms^-2)
		moveDirection.y -= gravity * Time.deltaTime;

		// Move the controller
		characterController.Move(moveDirection * Time.deltaTime);
	}
}
