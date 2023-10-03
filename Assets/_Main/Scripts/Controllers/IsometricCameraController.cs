using UnityEngine;

public class IsometricCameraController : MonoBehaviour
{
	public Transform target;
	public float distance = 10.0f;
	public Vector3 angles;
	public float rotationSpeed = 5.0f;

	private void Update()
	{
		if (target != null)
		{
			// Keyboard controls
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				angles.y -= rotationSpeed;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				angles.y += rotationSpeed;
			}
			if (Input.GetKey(KeyCode.UpArrow))
			{
				angles.x -= rotationSpeed;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				angles.x += rotationSpeed;
			}

			Vector3 direction = new Vector3(0, 0, -distance);
			Quaternion rotation = Quaternion.Euler(angles);
			transform.position = target.position + rotation * direction;
			transform.LookAt(target.position);
		}
	}
}
