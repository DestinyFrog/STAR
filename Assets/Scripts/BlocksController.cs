
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
    [SerializeField] public List<Block> blocksOrder = new List<Block>();
	[SerializeField] public int blocksLength = 4;
	[SerializeField] public Train train;

	void Awake() {
		ClearList();
	}

	// Limpa e reinicializa a lista de blocos, preenchendo com valores nulos até o comprimento desejado
	void ClearList() {
		blocksOrder.Clear();
		for(int i=0; i<blocksLength; i++) {
			blocksOrder.Add(null);
		}
	}

	// Define o bloco no slot especificado e verifica se a lista está completa
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

	// TODO 
	// Remove o bloco da lista 
	public void RemoveBlock(Block block) {
		Debug.Log("remove block");
	}

	// Verifica se todos os blocos estão na ordem correta
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

	// TODO
	// Conclui a tarefa
	public void Successfull() {
		train.PlaySuccessAnimation();
	}

	// Reinicia a posição de todos os blocos e limpa a lista quando a ordem está incorreta
	public void Wrong() {
		foreach (var block in blocksOrder) {
			block.resetPosition();
		}
		ClearList();
	}
}
