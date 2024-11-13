using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
	[SerializeField] public int order;

	// Define a posição do objeto arrastado para a posição do slot
    public void OnDrop(PointerEventData eventData) {
		if (eventData.pointerDrag != null) {
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
			setOrder( eventData.pointerDrag.GetComponent<Block>() );

			if(eventData.pointerDrag.GetComponent<Drag>().into)
				eventData.pointerDrag.GetComponent<Drag>().into.Clear();
			
			eventData.pointerDrag.GetComponent<Drag>().into = GetComponent<Slot>();
		}
	}

	// Define a ordem do bloco associando-o ao slot
	public void setOrder(Block block) {
		GameObject.FindWithTag("GameController").GetComponent<BlocksController>().SetBlock(this, block);
	}

	// Limpa o slot, removendo a referência ao bloco
	public void Clear() {
		GameObject.FindWithTag("GameController").GetComponent<BlocksController>().SetBlock(this, null);
	}
}
