using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropCanvas : MonoBehaviour,
	IBeginDragHandler,
	IEndDragHandler,
	IDragHandler,
	IDropHandler
{
	[SerializeField] private Canvas canvas;
	private RectTransform rectTransform;
	private CanvasGroup canvasGroup;

	private GameObject father;

	private void Awake() {
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
		father = null;
	}

	public void OnPointerDown(PointerEventData eventData) {

	}

	public void OnBeginDrag(PointerEventData eventData) {
		canvasGroup.alpha = .5f;
		canvasGroup.blocksRaycasts = false;
	}

	public void OnEndDrag(PointerEventData eventData) {
		canvasGroup.alpha = 1f;
		canvasGroup.blocksRaycasts = true;
	}

	public void OnDrag(PointerEventData eventData) {
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnDrop(PointerEventData eventData) {

	}

	// public MoveOnMouse(/*father*/) {
		// rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	// }
}
