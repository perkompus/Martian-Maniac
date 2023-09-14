using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

	public GameObject bubblePrefab;
	public float bubbleSize;
	//public int explosionSize;
	public float explosionDuration = 5f;

	private GameObject Bubble;

	public Vector3 TargetScale = Vector3.one * 1f;
	Vector3 startScale;
	Vector3 newScale;
	float t = 0;

	//fade out 
	// private Color alphaColor;
	// private float timeToFade = 1.0f;

	ParticleSystem ps;
	

	void Start()
	{
		TargetScale = Vector3.one * bubbleSize;
		ps = GetComponent<ParticleSystem>();
	}


	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{

			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}

			//Debug.Log("Object Created");
			Bubble = Instantiate(bubblePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			Bubble.transform.parent = gameObject.transform;
			startScale = new Vector3(1.0f,1.0f,1.0f);
			t = 0;
			ps.Play();
		}

		if (Bubble != null )
		{
			StartCoroutine(LerpGameObject());

		}

	}

	public IEnumerator LerpGameObject()
	{
		t += Time.deltaTime / explosionDuration;
		Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t * 30);
		Bubble.transform.localScale = newScale;
		yield return null;
	}

	
}


