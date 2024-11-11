using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.IO.Ports;

public class SerialController : MonoBehaviour {
	private SerialPort serial = new SerialPort("COM4", 9600);

	[SerializeField]
	public bool printColors = true;

	void Start() {
		serial.Open();
    }

	public RGBdata read() {
		string receivedString = serial.ReadLine();
		RGBdata data = RGBdata.fromJson(receivedString);
		return data;
	}

	public string getColor() {
		RGBdata data = read();
			 if ( Cor.branco.Check(data) )		return "branco";
		else if ( Cor.amarelo.Check(data) )		return "amarelo";
		else if ( Cor.azul.Check(data) )		return "azul";
		else if ( Cor.verde.Check(data) )		return "verde";
												return "";
	}

	void Update() {
		if (serial.IsOpen) {
			if (printColors) {
				Debug.Log( getColor() );
			}
		} else {
			serial.Open();
		}
	}
}
