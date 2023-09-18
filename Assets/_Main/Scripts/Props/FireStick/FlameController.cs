using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
	public float speed = 0.1f; // You can adjust this value to get the desired smoothness
	void Update()
	{
		// Create a quaternion for the target rotation (90 degrees around the Z axis)
		Quaternion targetRotation = Quaternion.Euler(0, 0, 0);

		// Use Lerp to rotate the GameObject smoothly
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed);
	}
}
