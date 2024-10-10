using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RGBdata {
	public int r;
	public int g;
	public int b;
	public int a;

	public static RGBdata fromJson(String str) {
		return JsonUtility.FromJson<RGBdata>(str);
	}
}