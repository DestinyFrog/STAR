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
	private bool once = true;
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

    // Update is called once per frame
    void Update() {
        string receivedString = serial.ReadLine();
		RGBdata data = RGBdata.fromJson(receivedString);

		if ( Cor.rosa.Check(data) && !currentList.Contains(pinkObject) ) {
			if (once) {
				once = false;
				currentList.Add( pinkObject );
				UpdateList();
			}
		}
		else if ( Cor.vermelho.Check(data) && !currentList.Contains(redObject) ) {
			if (once) {
				once = false;
				currentList.Add( redObject );
				UpdateList();
			}
		}
		else if ( Cor.amarelo.Check(data) && !currentList.Contains(yellowObject) ) {
			if (once) {
				once = false;
				currentList.Add( yellowObject );
				UpdateList();
			}
		}
		else if ( Cor.azul.Check(data) && !currentList.Contains(blueObject) ) {
			if (once) {
				once = false;
				currentList.Add( blueObject );
				UpdateList();
			}
		}
		else if ( Cor.verde.Check(data) && !currentList.Contains(greenObject) ) {
			if (once) {
				once = false;
				currentList.Add( greenObject );
				UpdateList();
			}
		}
		else {
			once = true;
		}
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
