using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	private Vector2 initialPosition;
	[SerializeField] public int order;

	// Inicializa a posição inicial do bloco com sua posição atual
	void Awake() {
		initialPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y);
	}

	// Restaura o bloco para sua posição inicial
	public void resetPosition() {
		GetComponent<RectTransform>().anchoredPosition = initialPosition;
	}
}
