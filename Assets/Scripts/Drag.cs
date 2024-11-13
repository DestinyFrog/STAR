using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
	[SerializeField] private Canvas canvas;
	private RectTransform rectTransform;
	private CanvasGroup canvasGroup;
	public Slot into = null;

	void Awake() {
		rectTransform = gameObject.GetComponent<RectTransform>();
		canvasGroup = gameObject.GetComponent<CanvasGroup>();
	}

	// Configura o objeto para o início do arraste: torna parcialmente transparente e permite a detecção de colisões
	public void OnBeginDrag(PointerEventData eventData) {
		canvasGroup.blocksRaycasts = false;
		canvasGroup.alpha = .6f;

		if (into)
			into.Clear();
	}

	// Move o objeto seguindo o movimento do mouse durante o arraste
	public void OnDrag(PointerEventData eventData) {
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;	
	}

	// Finaliza movimento do objeto
	public void OnEndDrag(PointerEventData eventData) {
		canvasGroup.blocksRaycasts = true;
		canvasGroup.alpha = 1f;
	}
}
