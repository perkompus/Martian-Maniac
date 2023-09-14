using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSpawner : MonoBehaviour
{
	[SerializeField] private GameObject engageMessage;
	[SerializeField] private GameObject hintMessage;

	public bool isEngageEnabled = false;
	public bool isHintEnabled = false;
	void Start()
	{
		RectTransform panelRectTransform = this.GetComponent<RectTransform>();
		float panelHeight = panelRectTransform.rect.height;
		float panelWidth = panelRectTransform.rect.width;

		if (isEngageEnabled == true)
		{
			var instance = Instantiate(engageMessage);
			instance.transform.SetParent(this.transform);
			RectTransform buttonRectTransform = instance.GetComponent<RectTransform>();
			buttonRectTransform.anchoredPosition = new Vector2(0, panelHeight * -0.5f + panelHeight * 0.2f);
		}

		if (isHintEnabled == true)
		{
			var instance = Instantiate(hintMessage);
			instance.transform.SetParent(this.transform);
			RectTransform buttonRectTransform = instance.GetComponent<RectTransform>();
			buttonRectTransform.anchoredPosition = new Vector2(0, panelHeight * -0.5f + panelHeight * 0.2f);
		}
	}
}
