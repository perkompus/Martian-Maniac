using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
	public SpriteRenderer sprite;
	private bool canFade;
	private Color alphaColor;
	[SerializeField] private float timeToFade = 15f;

	public void Start()
	{
		sprite = this.GetComponent<SpriteRenderer>();
		alphaColor = sprite.color;
		alphaColor.a = 0;

		
	}

	public void Update()
	{
		sprite.color = Color.Lerp(sprite.color, alphaColor, timeToFade * Time.deltaTime);
	}
}
