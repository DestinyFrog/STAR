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

	public void OnBeginDrag(PointerEventData eventData) {
		canvasGroup.blocksRaycasts = false;
		canvasGroup.alpha = .6f;

		if (into)
			into.Clear();
	}

	public void OnDrag(PointerEventData eventData) {
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;	
	}

	public void OnEndDrag(PointerEventData eventData) {
		canvasGroup.blocksRaycasts = true;
		canvasGroup.alpha = 1f;
	}
}
