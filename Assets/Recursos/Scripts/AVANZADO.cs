using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AVANZADO : MonoBehaviour {
	public RectTransform panelA, panelB, panelC, panelD, panelE, panelF, panelG, panelH, panelI;
	private Image imgA, imgB, imgC, imgD, imgE, imgF, imgG, imgH, imgI;

	public Button btnPrincipal;
	private Transform pos_btn_A, pos_btn_B, pos_btn_C, pos_btn_D, pos_btn_E, pos_btn_F, pos_btn_G, pos_btn_H, pos_btn_I;
	private int contador = 0, contador_r;
	private int r = 3; //conf_ini.num_repeticiones;
	private float velocidad = 150f; //conf_ini.velocidad_boton;
	public Text txtMsg;

	// Use this for initialization
	void Start () {
		InstanciarPosA ();
		//InstanciarPosB ();
		//InstanciarPosC ();
		//InstanciarPosD ();
		//InstanciarPosE ();
		//InstanciarPosF ();
		//InstanciarPosG ();
		//InstanciarPosH ();
		//InstanciarPosI ();
		imgA = panelA.GetComponent<Image> ();
		imgB = panelB.GetComponent<Image> ();
		imgC = panelC.GetComponent<Image> ();
		imgD = panelD.GetComponent<Image> ();
		imgE = panelE.GetComponent<Image> ();
		imgF = panelF.GetComponent<Image> ();
		imgG = panelG.GetComponent<Image> ();
		imgH = panelH.GetComponent<Image> ();
		imgI = panelI.GetComponent<Image> ();
		txtMsg.enabled = false;
		contador_r = 1;
		colors ("azul", imgA);
	}

	void colors (string nombre_color, Image panel) {
		rgb data = new rgb ();
		string conn = "URI=file:" + Application.dataPath + "/Recursos/BD/dbdata.db";
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection (conn);
		dbconn.Open ();
		IDbCommand dbcmd = dbconn.CreateCommand ();
		string sqlQuery = "Select r_color,g_color,b_color from color where nombre_color = '" + nombre_color + "'";
		Debug.Log (sqlQuery);
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader ();
		while (reader.Read ()) {
			//int id = reader.GetInt32(0);
			int r = reader.GetInt32 (0);
			int g = reader.GetInt32 (1);
			int b = reader.GetInt32 (2);
			data.r = r;
			data.g = g;
			data.b = b;
		}
		Debug.Log ("Color = (" + data.r + "," + data.g + "," + data.b + ")");
		panel.color = new Color (data.r, data.g, data.b);

		reader.Close ();
		reader = null;
		dbcmd.Dispose ();
		dbcmd = null;
		dbconn.Close ();
	}

	// Update is called once per frame
	void Update () {
		if (contador == 0) {
			if (pos_btn_A.position.x < ((Screen.width/3) - 100)  ) {
				//AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volumen);
				pos_btn_A.position += new Vector3 (Time.deltaTime * velocidad, 0f, 0f);
			}
			if (pos_btn_A.position.x >= ((Screen.width / 3 ) -100 )) {
				if (contador_r < r) {
					contador_r++;
					Destroy (pos_btn_A.gameObject);
					InstanciarPosA();
					//Debug.Log(contador_r);
				}
			}
		}
		if (contador == 1) {
			if (pos_btn_B.position.x < ((Screen.width/3) - 100)  ) {
				//AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volumen);
				pos_btn_B.position += new Vector3 (Time.deltaTime * velocidad, 0f, 0f);
			}
			if (pos_btn_B.position.x >= ((Screen.width / 3 ) -100 )) {
				if (contador_r > 1) {
					contador_r--;
					Destroy (pos_btn_B.gameObject);
					InstanciarPosB();
					//Debug.Log(contador_r);
				}
			}
		}

		if (contador == 2) {
			if (pos_btn_C.position.x > ((Screen.width/1.5)  + 100)  ) {
				//AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volumen);
				pos_btn_C.position += new Vector3 ( - Time.deltaTime * velocidad, 0f, 0f);
			}
			if (pos_btn_C.position.x <= ((Screen.width/1.5 )  + 100 )) {
				if (contador_r < r) {
					contador_r++;
					Destroy (pos_btn_C.gameObject);
					InstanciarPosC();
					//Debug.Log(contador_r);
				}
			}
		}
		if (contador == 3) {
			if (pos_btn_D.position.x > ((Screen.width/1.5)  + 100)  ) {
				//AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volumen);
				pos_btn_D.position += new Vector3 ( - Time.deltaTime * velocidad, 0f, 0f);
			}
			if (pos_btn_D.position.x <= ((Screen.width/1.5 )  + 100 )) {
				if (contador_r > 1) {
					contador_r--;
					Destroy (pos_btn_D.gameObject);
					InstanciarPosD();
					//Debug.Log(contador_r);
				}
			}
		}

		if (contador == 4) {
			if (pos_btn_E.position.x < ((Screen.width/3) - 100)  ) {
				//AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volumen);
				pos_btn_E.position += new Vector3 ( Time.deltaTime * velocidad, 0f, 0f);
			}
			if (pos_btn_E.position.x >= ((Screen.width / 3 ) -100 )) {
				if (contador_r < r) {
					contador_r++;
					Destroy (pos_btn_E.gameObject);
					InstanciarPosE();
					//Debug.Log(contador_r);
				}
			}
		}

		if (contador == 5) {
			if (pos_btn_F.position.y < ((Screen.height/3))  ) {
				//AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volumen);
				pos_btn_F.position += new Vector3 ( 0,Time.deltaTime * velocidad, 0f);
			}
			if (pos_btn_F.position.y >= ((Screen.height /3) )) {
				if (contador_r > 1) {
					contador_r--;
					Destroy (pos_btn_F.gameObject);
					InstanciarPosF();
					//Debug.Log(contador_r);
				}
			}
		}


		if (contador == 6) {
			if (pos_btn_G.position.x > ((Screen.width/1.5)  + 100)   ) {
				//AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volumen);
				pos_btn_G.position += new Vector3 ( -Time.deltaTime * velocidad,0, 0f);
			}
			if (pos_btn_G.position.x <= ((Screen.width/1.5 )  + 100 )) {
				if (contador_r < r) {
					contador_r++;
					Destroy (pos_btn_G.gameObject);
					InstanciarPosG();
					//Debug.Log(contador_r);
				}
			}
		}
		if (contador == 7) {
			if (pos_btn_H.position.y > ((Screen.height/1.5) )   ) {
				//AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volumen);
				pos_btn_H.position += new Vector3 ( 0, -Time.deltaTime * velocidad, 0f);
			}
			if (pos_btn_H.position.y <= ((Screen.height/1.5 )  )) {
				if (contador_r > 1) {
					contador_r--;
					Destroy (pos_btn_H.gameObject);
					InstanciarPosH();
					//Debug.Log(contador_r);
				}
			}
		}

		if (contador == 8) {
			
				if (contador_r < r) {
					contador_r++;
					Destroy (pos_btn_I.gameObject);
					Debug.Log(contador_r);
					InstanciarPosI();
				}
			
		}
	}

	void InstanciarPosA () {
		//POSICIONES INICIALES
		btnPrincipal.GetComponentInChildren<Text> ().text = "Izquierda Arriba";
		//btnPrincipal.onClick.AddListener(contar);
		GameObject btnIzqSup = Instantiate (btnPrincipal.gameObject, new Vector3 (-100, (Screen.height / 6) * 5, 0), transform.rotation);
		Debug.Log ("contador_r = " + contador_r + " y r = " + r);
		btnIzqSup.transform.SetParent (this.transform);
		pos_btn_A = btnIzqSup.GetComponent<Transform> ();
		if (contador_r == r) {
			pos_btn_A.GetComponent<Button>().onClick.AddListener(contar);
		}
	}

	void InstanciarPosB () {
		//POSICIONES INICIALES
		btnPrincipal.GetComponentInChildren<Text> ().text = "Izquierda Abajo";
		//btnPrincipal.onClick.AddListener(contar);
		GameObject btnIzqSup = Instantiate (btnPrincipal.gameObject, new Vector3 (-100, Screen.height / 6, 0), transform.rotation);
		Debug.Log ("contador_r = " + contador_r + " y r = " + r);
		btnIzqSup.transform.SetParent (this.transform);
		pos_btn_B = btnIzqSup.GetComponent<Transform> ();
		if (contador_r == 1) {
			pos_btn_B.GetComponent<Button>().onClick.AddListener(contar);
		}
	}
	void InstanciarPosC () {
		//POSICIONES INICIALES
		btnPrincipal.GetComponentInChildren<Text> ().text = "Derecha Abajo";
		//btnPrincipal.onClick.AddListener(contar);
		GameObject btnIzqSup = Instantiate (btnPrincipal.gameObject, new Vector3 (Screen.width + 100, Screen.height / 6, 0), transform.rotation);
		Debug.Log ("contador_r = " + contador_r + " y r = " + r);
		btnIzqSup.transform.SetParent (this.transform);
		pos_btn_C = btnIzqSup.GetComponent<Transform> ();
		if (contador_r == r) {
			pos_btn_C.GetComponent<Button>().onClick.AddListener(contar);
		}
	}

	void InstanciarPosD () {
		//POSICIONES INICIALES
		btnPrincipal.GetComponentInChildren<Text> ().text = "Derecha Arriba";
		//btnPrincipal.onClick.AddListener(contar);
		GameObject btnIzqSup = Instantiate (btnPrincipal.gameObject, new Vector3 (Screen.width + 100, (Screen.height / 6) * 5, 0), transform.rotation);
		Debug.Log ("contador_r = " + contador_r + " y r = " + r);
		btnIzqSup.transform.SetParent (this.transform);
		pos_btn_D = btnIzqSup.GetComponent<Transform> ();
		if (contador_r == 1) {
			pos_btn_D.GetComponent<Button>().onClick.AddListener(contar);
		}
	}

	void InstanciarPosE () {
		//POSICIONES INICIALES
		btnPrincipal.GetComponentInChildren<Text> ().text = "Izquierda Medio";
		//btnPrincipal.onClick.AddListener(contar);
		GameObject btnIzqSup = Instantiate (btnPrincipal.gameObject, new Vector3 (-100, Screen.height / 2, 0), transform.rotation);
		Debug.Log ("contador_r = " + contador_r + " y r = " + r);
		btnIzqSup.transform.SetParent (this.transform);
		pos_btn_E = btnIzqSup.GetComponent<Transform> ();
		if (contador_r == r) {
			pos_btn_E.GetComponent<Button>().onClick.AddListener(contar);
		}
	}

	void InstanciarPosF () {
		//POSICIONES INICIALES
		btnPrincipal.GetComponentInChildren<Text> ().text = "Abajo Medio";
		//btnPrincipal.onClick.AddListener(contar);
		GameObject btnIzqSup = Instantiate (btnPrincipal.gameObject, new Vector3 (Screen.width / 2, -50, 0), transform.rotation);
		Debug.Log ("contador_r = " + contador_r + " y r = " + r);
		btnIzqSup.transform.SetParent (this.transform);
		pos_btn_F = btnIzqSup.GetComponent<Transform> ();
		if (contador_r == 1) {
			pos_btn_F.GetComponent<Button>().onClick.AddListener(contar);
		}
	}

	void InstanciarPosG () {
		//POSICIONES INICIALES
		btnPrincipal.GetComponentInChildren<Text> ().text = "Derecha Medio";
		//btnPrincipal.onClick.AddListener(contar);
		GameObject btnIzqSup = Instantiate (btnPrincipal.gameObject, new Vector3 (Screen.width + 100, Screen.height / 2, 0), transform.rotation);
		Debug.Log ("contador_r = " + contador_r + " y r = " + r);
		btnIzqSup.transform.SetParent (this.transform);
		pos_btn_G = btnIzqSup.GetComponent<Transform> ();
		if (contador_r == r) {
			pos_btn_G.GetComponent<Button>().onClick.AddListener(contar);
		}
	}

	void InstanciarPosH () {
		//POSICIONES INICIALES
		btnPrincipal.GetComponentInChildren<Text> ().text = "Arriba Medio";
		//btnPrincipal.onClick.AddListener(contar);
		GameObject btnIzqSup = Instantiate (btnPrincipal.gameObject, new Vector3 (Screen.width / 2, Screen.height + 50, 0), transform.rotation);
		Debug.Log ("contador_r = " + contador_r + " y r = " + r);
		btnIzqSup.transform.SetParent (this.transform);
		pos_btn_H = btnIzqSup.GetComponent<Transform> ();
		if (contador_r == 1) {
			pos_btn_H.GetComponent<Button>().onClick.AddListener(contar);
		}
	}

	void InstanciarPosI () {
		//POSICIONES INICIALES
		btnPrincipal.GetComponentInChildren<Text> ().text = "Centro";
		//btnPrincipal.onClick.AddListener(contar);
		GameObject btnIzqSup = Instantiate (btnPrincipal.gameObject, new Vector3 (Screen.width / 2, Screen.height / 2, 0), transform.rotation);
		Debug.Log ("contador_r = " + contador_r + " y r = " + r);
		btnIzqSup.transform.SetParent (this.transform);
		pos_btn_I =btnIzqSup.GetComponent<Transform> ();
		if (contador_r == r) {
			pos_btn_I.GetComponent<Button>().onClick.AddListener(contar);
		}
	}


		void contar (){
		contador++;
		Debug.Log(contador);
		if(contador == 1 ){
			//datosPosicion(6);
			imgA.color = Color.white;
			//colors(conf_ini.b, imgB);
			colors("amarillo", imgB);
			Destroy(pos_btn_A.gameObject);
			InstanciarPosB();
		}
		if(contador == 2){
			//datosPosicion(7);
			imgB.color = Color.white;
			//colors(conf_ini.c, imgC);
			colors("verde", imgC);
			Destroy(pos_btn_B.gameObject);
			InstanciarPosC();
		}
		if(contador == 3){
			//datosPosicion(8);
			imgC.color = Color.white;
			colors("rojo", imgD);
			//colors(conf_ini.d, imgD);
			Destroy(pos_btn_C.gameObject);
			InstanciarPosD();
		}
		if(contador == 4){
			imgD.color = Color.white;
			colors("amarillo", imgE);
			Destroy(pos_btn_D.gameObject);
			InstanciarPosE();
		}

		if(contador == 5){
			imgE.color = Color.white;
			colors("azul", imgF);
			Destroy(pos_btn_E.gameObject);
			InstanciarPosF();
		}
		if(contador == 6){
			imgF.color = Color.white;
			colors("verde", imgG);
			Destroy(pos_btn_F.gameObject);
			InstanciarPosG();
		}
		if(contador == 7){
			imgG.color = Color.white;
			colors("negro", imgH);
			Destroy(pos_btn_G.gameObject);
			InstanciarPosH();
		}
		if(contador == 8){
			imgH.color = Color.white;
			colors("celeste", imgI);
			Destroy(pos_btn_H.gameObject);
			InstanciarPosI();
		}
		
	}
}