using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.HID.HID;
using static UnityEngine.Rendering.DebugUI;

public class KeySpawner : MonoBehaviour
{
	[SerializeField] private GameObject spaceButton;

	public bool isSpaceEnabled = false;
	void Start()
    {
		RectTransform panelRectTransform = this.GetComponent<RectTransform>();
		float panelHeight = panelRectTransform.rect.height;
		float panelWidth = panelRectTransform.rect.width;

		if (isSpaceEnabled)
		{
			var instance = Instantiate(spaceButton);
			instance.transform.SetParent(this.transform);
			RectTransform buttonRectTransform = instance.GetComponent<RectTransform>();
			buttonRectTransform.anchoredPosition = new Vector2(0 , panelHeight * -0.5f+ panelHeight*0.2f);
		}
		
	}

}
