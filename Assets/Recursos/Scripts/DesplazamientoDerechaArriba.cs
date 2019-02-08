using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazamientoDerechaArriba : MonoBehaviour {

	private float velocidad = 25f;
	public int maxX,maxY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	// Update is called once per frame
	void Update () {
		Transform mov = GetComponent<Transform>();

		if(mov.position.x < maxX){
			mov.position += new Vector3(Time.deltaTime * velocidad,0f,0f);
		}
		if(mov.position.x > maxX && mov.position.y < maxY ){
			mov.position += new Vector3(0f, Time.deltaTime * velocidad,0f);
		}
		
	}
}
