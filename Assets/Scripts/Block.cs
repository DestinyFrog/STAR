using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	private Vector2 initialPosition;
	[SerializeField] public int order;

	void Awake() {
		initialPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y);
	}

	public void resetPosition() {
		GetComponent<RectTransform>().anchoredPosition = initialPosition;
	}
}
