using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cor {
	public static Cor amarelo = new Cor("amarelo", 1683,250,2353,385,645,121,2156,602, Color.yellow, 20);
	public static Cor azul = new Cor("azul", 2301,1643,2994,1704,749,417,2090,883, Color.blue, 20);
	public static Cor verde = new Cor("verde", 2172,749,2736,791,745,267,2249,921, Color.green, 20);
	public static Cor vermelho = new Cor("vermelho", 1878,473,3175,1339,766,268,2279,923, Color.red, 60);
	public static Cor branco = new Cor("branco", 1538,146,1824,165,504,41,1397,124, Color.white, 20);

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
