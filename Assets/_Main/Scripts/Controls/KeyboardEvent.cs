using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceBarEvent : MonoBehaviour
{

    [SerializeField] private GameObject spaceButton;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
			spaceButton.GetComponent<Button>().onClick.Invoke();
			Debug.Log("Space bar pressed!");
        }   
    }
}
