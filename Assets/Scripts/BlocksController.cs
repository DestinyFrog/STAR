
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
	[SerializeField] private Animator animator;
    [SerializeField] public List<Block> blocksOrder = new List<Block>();
	[SerializeField] public int blocksLength = 4;

	void Awake() {
		ClearList();
	}

	// Limpa e reinicializa a lista de blocos, preenchendo com valores nulos até o comprimento desejado
	public void ClearList() {
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
		animator.SetTrigger("right");
	}

	// Reinicia a posição de todos os blocos e limpa a lista quando a ordem está incorreta
	public void Wrong() {
		animator.SetTrigger("wrong");
		foreach (var block in blocksOrder) {
			block.resetPosition();
		}
		ClearList();
	}
}
