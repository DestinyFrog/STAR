using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.IO;
using System.IO.Ports;

public class Cor {
	public static Cor amarelo = new Cor("amarelo", 449,344,751,582,265,203,764,537, Color.yellow, 20);
	public static Cor azul = new Cor("azul", 592,424,837,654,291,224,645,522, Color.blue, 20);
	public static Cor verde = new Cor("verde", 738,641,916,876,351,332,859,810, Color.green, 20);
	public static Cor vermelho = new Cor("vermelho", 430,400,827,796,286,264,708,676, Color.red, 60);

	private int max_r, min_r;
	private int max_g, min_g;
	private int max_b, min_b;
	private int max_a, min_a;
	public string cor;
	public Color rgb;

	public Cor(string cor, int max_r, int min_r, int max_g, int min_g, int max_b, int min_b, int max_a, int min_a, Color rgb) {
		this.cor = cor;
		this.max_r = max_r;
		this.min_r = min_r;
		this.max_g = max_g;
		this.min_g = min_g;
		this.max_b = max_b;
		this.min_b = min_b;
		this.max_a = max_a;
		this.min_a = min_a;
		this.rgb = rgb;
	}

	public Cor(string cor, int max_r, int min_r, int max_g, int min_g, int max_b, int min_b, int max_a, int min_a, Color rgb, int offset) {
		this.cor = cor;
		this.max_r = max_r + offset;
		this.min_r = min_r - offset;
		this.max_g = max_g + offset;
		this.min_g = min_g - offset;
		this.max_b = max_b + offset;
		this.min_b = min_b - offset;
		this.max_a = max_a + offset;
		this.min_a = min_a - offset;
		this.rgb = rgb;
	}

	public bool Check(RGBdata data) {
		return
			( data.r >= min_r && data.r <= max_r ) &&
			( data.g >= min_g && data.g <= max_g ) &&
			( data.b >= min_b && data.b <= max_b ) &&
			( data.a >= min_a && data.a <= max_a )
		;
	}
}

[Serializable]
public class RGBdata {
	public int r;
	public int g;
	public int b;
	public int a;
}

public class GameController : MonoBehaviour
{
	SerialPort serial = new SerialPort("COM4", 9600);
	List<Cor> order = new List<Cor>();

	private bool once = true;

	[SerializeField]
	public List<Image> ordGameObject;

    // Start is called before the first frame update
    void Start()
    {
        serial.Open();
    }

    // Update is called once per frame
    void Update()
    {
        string receivedString = serial.ReadLine();
		RGBdata data = JsonUtility.FromJson<RGBdata>(receivedString);

		if ( Cor.vermelho.Check(data) ) {
			if (once) {
				once = false;
				order.Add( Cor.vermelho );
			}
		}
		else if ( Cor.amarelo.Check(data) ) {
			if (once) {
				once = false;
				order.Add( Cor.amarelo );
			}
		}
		else if ( Cor.azul.Check(data) ) {
			if (once) {
				once = false;
				order.Add( Cor.azul );
			}
		}
		else if ( Cor.verde.Check(data) ) {
			if (once) {
				once = false;
				order.Add( Cor.verde );
			}
		}
		else {
			once = true;
		}

		if (once == true) {
			for (int i = 0; i < order.Count; i++) {
				ordGameObject[i].color = order[i].rgb;
			}

			Debug.Log( order[ order.Count-1 ].cor );
		}

    }
}
