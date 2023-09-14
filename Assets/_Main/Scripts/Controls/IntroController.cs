using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;

public class IntroController : MonoBehaviour
{

	public TMP_Text text;
	public float duration = 1f;
	public float blinkingIntervel = 0.2f;

	private bool spaceEnabled = false;
	private bool blinkingEnabled = false;

	private void Start()
	{
		Invoke("StartMyCoroutine", 3f);
	}
	private void Update()
	{
		if (Input.GetKey(KeyCode.Space) && spaceEnabled)
		{
			blinkingEnabled = false;
			SceneManager.LoadScene("IntroMenu");
		}
	}

	void StartMyCoroutine()
	{
		StartCoroutine(MyCoroutine());
	}

	IEnumerator MyCoroutine()
	{
		Image image = text.GetComponentInParent<Image>();
		Color startColor = image.color;
		Color endColor = startColor;
		endColor.a = 1f;

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			elapsedTime += Time.deltaTime;
			image.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
			yield return null;
		}
		print("Space Button is enabled");
		spaceEnabled = true;
		blinkingEnabled = true;
		StartCoroutine(StartBlinking());
	}

	IEnumerator StartBlinking()
	{
		Image image = text.GetComponentInParent<Image>();
		Color startColor = image.color;
		Color endColor = startColor;
		endColor.a = 0f;

		while (blinkingEnabled)
		{
			// Fade out
			float elapsedTime = 0f;
			while (elapsedTime < duration)
			{
				elapsedTime += Time.deltaTime;
				image.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
				yield return null;
			}

			// Fade in
			elapsedTime = 0f;
			while (elapsedTime < duration)
			{
				elapsedTime += Time.deltaTime;
				image.color = Color.Lerp(endColor, startColor, elapsedTime / duration);
				yield return null;
			}
		}
	}
}
