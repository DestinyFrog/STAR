using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cor {
	public static Cor amarelo = new Cor("amarelo", 1895,1420,2411,1902,680,550,2172,1898, Color.yellow, 20);
	public static Cor azul = new Cor("azul", 3077,2661,3379,2603,890,684,2307,1590, Color.blue, 20);
	public static Cor verde = new Cor("verde", 2597,2242,2705,2171,784,650,2275,1934, Color.green, 20);
	public static Cor vermelho = new Cor("vermelho", 2065,1437,3128,2600,781,614,2294,1920, Color.red, 60);
	public static Cor rosa = new Cor("rosa", 1889,1308,2290,1624,604,430,1632,1111, Color.magenta, 20);

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
