using UnityEngine;

public class FireStick : MonoBehaviour
{
	public Transform target; // Assign the target in the inspector

	void Update()
	{
		// Get the direction vector from this GameObject to the target
		Vector3 direction = target.position - transform.position;

		// Calculate the angle
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		// Set the rotation to make this GameObject look towards the target
		transform.rotation = Quaternion.Euler(0, 0, angle - 90);
	}
}
