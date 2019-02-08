using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APRENDIZAJE : MonoBehaviour {

	// Use this for initialization
	public int contador = 0;
	public float velocidad = 25f;
	public Button btnA, btnB, btnC, btnD;
	private Transform movB, movA, movC, movD;
	void Start () {
		movA = btnA.transform;
		btnB.interactable = false;
		movB = btnB.transform;
		btnC.interactable = false;
		movC = btnC.transform;
		btnD.interactable = false;
		movD = btnD.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(contador == 0){
			Transform movA = btnA.transform;
			if(movA.position.x < 285){
				movA.position += new Vector3(Time.deltaTime * velocidad,0f,0f);
			}
			if(movA.position.x > 285 && movA.position.y < 300 ){
				movA.position += new Vector3(0f, Time.deltaTime * velocidad,0f);
			}
		}

		if(contador == 3){
			if(movB.position.x < 285){
				movB.position += new Vector3(Time.deltaTime * velocidad,0f,0f);
			}
			if(movB.position.x > 285 && movB.position.y > 30 ){
				movB.position += new Vector3(0f, - Time.deltaTime * velocidad*2,0f);
				if(movB.position.y < 30){
					btnB.interactable = true;
				}
			}
		}

		if(contador == 6){
			if(movC.position.x > 490){
				movC.position += new Vector3( - Time.deltaTime * velocidad,0f,0f);
			}
			if(movC.position.x < 490 && movC.position.y > 30 ){
				movC.position += new Vector3(0f, - Time.deltaTime * velocidad*2,0f);
				if(movC.position.y < 30){
					btnC.interactable = true;
				}
			}
		}

		if(contador == 9){
			if(movD.position.x > 490){
				movD.position += new Vector3( - Time.deltaTime * velocidad,0f,0f);
			}
			if(movD.position.x < 490 && movD.position.y < 300 ){
				movD.position += new Vector3(0f,  Time.deltaTime * velocidad * 2,0f);
				btnD.interactable = true;
				if(movD.position.y > 300){
					btnD.interactable = true;
				}
			}
		}
	}

	public void click(){
		
		Debug.Log(contador);
		
		contador++;
		if(contador == 3){
			Destroy(btnA.gameObject, 0.1f);
		}
		if(contador == 6){
			Destroy(btnB.gameObject, 0.1f);
		}
		if(contador == 9){
			Destroy(btnC.gameObject, 0.1f);
		}
		if(contador == 12){
			Destroy(btnD.gameObject, 0.1f);
		}

	}

}
