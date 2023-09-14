using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class IntroMenuController : MonoBehaviour
{
	public Button[] buttons;

	public float newExtraFontSize;
	public Color newColor;
	private Color originalColor;

	public Color newButtonColor;
	private Color originalButtonColor;

	public FontStyles fontStyle;

	void Start()
	{
		foreach (Button button in buttons)
		{
			TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
			Color originalColor = text.color;
			float originalFontSize = text.fontSize;
			FontStyles originalFontStyle = text.fontStyle;

			Color originalButtonColor = button.GetComponent<Image>().color;

			EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
			EventTrigger.Entry entryEnter = new EventTrigger.Entry();
			entryEnter.eventID = EventTriggerType.PointerEnter;
			entryEnter.callback.AddListener((eventData) => { OnPointerEnter((PointerEventData)eventData, button, newColor, originalFontSize + newExtraFontSize, fontStyle, newButtonColor); });
			trigger.triggers.Add(entryEnter);

			EventTrigger.Entry entryExit = new EventTrigger.Entry();
			entryExit.eventID = EventTriggerType.PointerExit;
			entryExit.callback.AddListener((eventData) => { OnPointerExit((PointerEventData)eventData, button, originalColor, originalFontSize, originalFontStyle, originalButtonColor); });
			trigger.triggers.Add(entryExit);
		}
	}


	public void OnPointerEnter(PointerEventData eventData, Button button, Color color, float fontSize, FontStyles fontStyle, Color buttonColor)
	{
		TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
		text.color = color;
		text.fontSize = fontSize;
		text.fontStyle = fontStyle;

		button.GetComponent<Image>().color = buttonColor;
	}

	public void OnPointerExit(PointerEventData eventData, Button button, Color color, float fontSize, FontStyles fontStyle, Color buttonColor)
	{
		TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
		text.color = color;
		text.fontSize = fontSize;
		text.fontStyle = fontStyle;

		button.GetComponent<Image>().color = buttonColor;
	}
}
