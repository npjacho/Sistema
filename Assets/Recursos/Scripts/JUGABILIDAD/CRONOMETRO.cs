using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRONOMETRO : MonoBehaviour {

	public static float cuentaAtras = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cuentaAtras = cuentaAtras + Time.deltaTime;
	}
}
