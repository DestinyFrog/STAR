using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.IO.Ports;

public class GameController : MonoBehaviour
{
	// private bool once = true;
	private SerialPort serial = new SerialPort("COM4", 9600);

	private List<GameObject> currentList = new List<GameObject>();
	[SerializeField] public List<GameObject> slots = new List<GameObject>();
	[SerializeField] public List<GameObject> correctBlocks = new List<GameObject>();

	[Header("Colors and Objects")]
	[SerializeField] public GameObject pinkObject;
	[SerializeField] public GameObject yellowObject;
	[SerializeField] public GameObject redObject;
	[SerializeField] public GameObject greenObject;
	[SerializeField] public GameObject blueObject;

    // Start is called before the first frame update
    void Start() {
        serial.Open();
    }

	public void Add(GameObject obj) {
		currentList.Add(obj);
		UpdateList();
	}

	void UpdateList() {
		for (int i = 0; i < currentList.Count; i++) {
			currentList[i].transform.SetParent(slots[i].transform);
			currentList[i].transform.localPosition = Vector3.zero;
		}

		if (currentList.Count >= 5) {
			End();
		}
	}

	void End() {
		bool eq = true;
		for (int i = 0; i < currentList.Count; i++) {
			if ( currentList[i] != correctBlocks[i] ) {
				eq = false;
			}
		}

		Debug.Log( eq? "Vitória" : "Derrota" );
		serial.Close();
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}
}
