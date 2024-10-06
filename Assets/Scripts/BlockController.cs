using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockController : MonoBehaviour,
	IDropHandler
{
	private List<Block> blocks;


	public void OnPointerDown(PointerEventData eventData) {}

	public void OnDrop(PointerEventData eventData) {
	}
}
