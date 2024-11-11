
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
    [SerializeField] public List<Block> blocksOrder = new List<Block>();
	[SerializeField] public int length = 4;

	void Awake() {
		ClearList();
	}

	void ClearList() {
		blocksOrder.Clear();
		for(int i=0; i<length; i++) {
			blocksOrder.Add(null);
		}
	}

	public int SetBlock(Slot slot, Block block) {
		blocksOrder[slot.order] = block;

		var thereIsNull = false;
		foreach (var bl in blocksOrder) {
			if (bl == null) {
				thereIsNull=true;
				break;
			}
		}

		if (!thereIsNull)
			Verify();

		return slot.order;
	}

	public void RemoveBlock(Block block) {
		Debug.Log("remove block");
	}

	public void Verify() {
		int last = -1;
		foreach (var block in blocksOrder) {
			if (block.order != last+1) {
				Wrong();
				return;
			}
			last++;
		}
		Successfull();
	}

	public void Successfull() {
		Debug.Log("successful");
	}

	public void Wrong() {
		foreach (var block in blocksOrder) {
			block.resetPosition();
		}
		ClearList();
	}
}
