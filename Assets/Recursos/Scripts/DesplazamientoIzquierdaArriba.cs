using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazamientoIzquierdaArriba : MonoBehaviour {
	private float velocidad = 100f;
	public int maxX,maxY;
	private int contador = 0;

	// Use this for initialization
	void Start () {
		
	}

    internal void StartCoroutine_Auto()
    {
        throw new NotImplementedException();
    }


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
