using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class AVANZADO : MonoBehaviour {
	public RectTransform panelA,panelB,panelC,panelD,panelE,panelF,panelG,panelH,panelI;
	private Image imgA,imgB,imgC,imgD,imgE,imgF,imgG,imgH,imgI;

	public Button btnPrincipal;
	private Transform pos_btn_A,pos_btn_B,pos_btn_C,pos_btn_D,pos_btn_E,pos_btn_F,pos_btn_G,pos_btn_H,pos_btn_I;
	private int contador = 0, contador_r;
	private int r =  3;//conf_ini.num_repeticiones;
	private float velocidad = 120f;//conf_ini.velocidad_boton;
	public Text txtMsg;

	// Use this for initialization
	void Start () {
		txtMsg.enabled = false;
		contador_r = 1;
		colors("azul", imgA);
	}

	void colors(string nombre_color, Image panel){
		rgb  data = new rgb();
		string conn = "URI=file:" + Application.dataPath + "/Recursos/BD/dbdata.db";
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open();
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "Select r_color,g_color,b_color from color where nombre_color = '" + nombre_color + "'" ;
		Debug.Log(sqlQuery);
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
			while(reader.Read()){
				//int id = reader.GetInt32(0);
				int r = reader.GetInt32(0);
				int g = reader.GetInt32(1);
				int b = reader.GetInt32(2);
				data.r = r;
				data.g = g;
				data.b = b; 
		}
			Debug.Log("Color = (" + data.r + "," + data.g + "," + data.b + ")" );
			panel.color = new Color(data.r,data.g,data.b);

		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
	}


	// Update is called once per frame
	void Update () {
		
	}

	void InstanciarPosA(){
				//POSICIONES INICIALES
		btnPrincipal.GetComponentInChildren<Text>().text = "Izquierda Superior";
		//btnPrincipal.onClick.AddListener(contar);
		GameObject btnIzqSup = Instantiate(btnPrincipal.gameObject,new Vector3(-100 ,(Screen.height/2) + 25  ,0),transform.rotation);
		Debug.Log( "contador_r = " + contador_r + " y r = " + r);
		btnIzqSup.transform.SetParent(this.transform);
		pos_btn_A = btnIzqSup.GetComponent<Transform>();
		if(contador_r == r){
		//pos_btn_A.GetComponent<Button>().onClick.AddListener(contar);
		}
	}
}

