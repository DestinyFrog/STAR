using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
	[SerializeField] public int order;

    public void OnDrop(PointerEventData eventData) {
		if (eventData.pointerDrag != null) {
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
			setOrder( eventData.pointerDrag.GetComponent<Block>() );
			eventData.pointerDrag.GetComponent<Drag>().into = GetComponent<Slot>();
		}
	}

	public void setOrder(Block block) {
		GameObject.FindWithTag("GameController").GetComponent<BlocksController>().SetBlock(this, block);
	}

	public void Clear() {
		GameObject.FindWithTag("GameController").GetComponent<BlocksController>().SetBlock(this, null);
	}
}
