using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SELEC_LEVEL_JUGABILIDAD : MonoBehaviour {

	// Use this for initialization
	public Text fecha;
	public Text titulo;

//Nivel Basico A, Basico B, Intermedio, Avanzado
	public GameObject btnA,btnB,btnC,btnD;
	void Start () {
		fecha.text = LOGIN_JUGABILIDAD.fecha;
		titulo.text = "Bienvenido " + LOGIN_JUGABILIDAD.nombre_usuario_log + "a la sección de jugabilidad";
		if( LOGIN_JUGABILIDAD.a == false ){
			btnA.SetActive(false);
		}
		if( LOGIN_JUGABILIDAD.b == false ){
			btnB.SetActive(false);
		}
		if( LOGIN_JUGABILIDAD.c == false ){
			btnC.SetActive(false);
		}
		if( LOGIN_JUGABILIDAD.d == false ){
			btnD.SetActive(false);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void regresarMenu(){
		SceneManager.LoadScene(0);
	}
}
