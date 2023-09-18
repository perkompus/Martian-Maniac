using UnityEngine;

public class FireStickPosition : MonoBehaviour
{
	private Camera mainCamera;
	public float speed = 0.1f; // You can adjust this value to get the desired smoothness
	public Transform target; // Assign the target in the inspector


	void Start()
	{
		mainCamera = Camera.main;
	}

	void Update()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
		mousePosition.z = 0; // Keep the z position at 0 as it's a 2D game

		// Use Lerp to move the GameObject smoothly
		transform.position = Vector3.Lerp(transform.position, mousePosition, speed);

		// Get the direction vector from this GameObject to the target
		Vector3 direction = target.position - transform.position;

		// Calculate the angle
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		// Set the rotation to make this GameObject look towards the target
		transform.rotation = Quaternion.Euler(0, 0, angle - 90);
	}
}
