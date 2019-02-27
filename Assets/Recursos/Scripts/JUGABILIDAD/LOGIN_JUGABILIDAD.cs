using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class LOGIN_JUGABILIDAD : MonoBehaviour {

	public InputField txtUser,txtPass;
	private int codigo_ususario = 0;
	private int codigo_aprendizaje;

	public Text msg;
	public Text lblfecha;
	public static string fecha;
	public static string nombre_usuario_log;

	public static bool a=false,b=false,c=false,d=false;
	public static List<int> codigos_detalles_aprendizajes = new List<int>();


	// Use this for initialization
	void Start () {
		fecha = System.DateTime.Now.ToString("dd/MM/yyyy");
		lblfecha.text = fecha;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void login(){
		Debug.Log(txtUser.text +" --- "+ txtPass.text);
		loginUsuario(txtUser.text, txtPass.text);

		foreach (int value in codigos_detalles_aprendizajes)
        {
            Debug.Log("id_aprendizaje: " + value);
        }

		SceneManager.LoadScene(15);

	}

	void loginUsuario ( string user, string pass) {
		codigo_ususario = 0;
		string conn = "URI=file:" + Application.dataPath + "/Recursos/BD/dbdata.db";
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection (conn);
		dbconn.Open ();
		IDbCommand dbcmd = dbconn.CreateCommand ();
		string sqlQuery = "select id_usuario from usuario where nombre_usuario = '" + user + "' and password_usuario = '" + pass + "'";
		Debug.Log(sqlQuery);
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader ();
		while (reader.Read ()) {
			codigo_ususario = reader.GetInt32(0);
		}
		reader.Close ();
		reader = null;
		dbcmd.Dispose ();
		dbcmd = null;
		dbconn.Close ();
		if(codigo_ususario == 0){
			msg.text = "Usuario y/o Contraseña incorrecto!.. Intene otra vez.";
			txtUser.text = "";
			txtPass.text = "";
		}else{
			msg.text = "Usuario Encotrado!";
			nombre_usuario_log = user;
			verificarDatosAprendizaje(codigo_ususario,fecha);
		}
	}

	void verificarDatosAprendizaje ( int codigo_usuario, string fecha) {
		codigo_aprendizaje = 0;
		string conn = "URI=file:" + Application.dataPath + "/Recursos/BD/dbdata.db";
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection (conn);
		dbconn.Open ();
		IDbCommand dbcmd = dbconn.CreateCommand ();
		string sqlQuery = "select * from aprendizaje where fecha_aprendizaje = '" + fecha + "' and id_usuario = " + codigo_usuario ;
		Debug.Log(sqlQuery);
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader ();
		while (reader.Read ()) {
			codigo_aprendizaje = reader.GetInt32(0);
		}
		reader.Close ();
		reader = null;
		dbcmd.Dispose ();
		dbcmd = null;
		dbconn.Close ();
		if(codigo_aprendizaje == 0){
			Debug.Log("No tiene niveles registrados el dia de hoy.");
			//msg.text = "Usuario y/o Contraseña incorrecto!.. Intene otra vez.";
			//txtUser.text = "";
			//txtPass.text = "";
		}else{
			Debug.Log("Si tiene niveles registrados hoy.");
			verificarNiveles(codigo_aprendizaje);
		}
	}

	

	public void verificarNiveles (int codigo_aprendizaje) {
		int ubicacion = 0;
		string conn = "URI=file:" + Application.dataPath + "/Recursos/BD/dbdata.db";
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection (conn);
		dbconn.Open ();
		IDbCommand dbcmd = dbconn.CreateCommand ();
		string sqlQuery = "select id_detalle_apre,id_ubicacion  from detalle_aprendizaje where detalle_aprendizaje.id_aprendizaje = " + codigo_aprendizaje ;
		Debug.Log(sqlQuery);
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader ();
		while (reader.Read ()) {
			//añadiendo los id del detalle de aprendizaje
			codigos_detalles_aprendizajes.Add(reader.GetInt32(0));
			ubicacion = reader.GetInt32(1);
			if( ubicacion == 1 || ubicacion == 2){
				Debug.Log("Tiene nivel A");
				a = true;
			}
			if( ubicacion == 3 || ubicacion == 4){
				Debug.Log("Tiene nivel B");
				b = true;
			}
			if( ubicacion >= 5 && ubicacion <= 8){
				Debug.Log("Tiene nivel C");
				c = true;
			}
			if( ubicacion >= 9 && ubicacion <= 17){
				Debug.Log("Tiene nivel D");
				d = true;
			}
		}
		Debug.Log("Niveles =>>");
		Debug.Log("a = " + a);
		Debug.Log("b = " + b);
		Debug.Log("c = " + c);
		Debug.Log("d = " + d);

		// foreach (int value in codigos_detalles_aprendizajes)
        // {
        // 	Debug.Log("id_aprendizaje: " + value);
        // }

		reader.Close ();
		reader = null;
		dbcmd.Dispose ();
		dbcmd = null;
		dbconn.Close ();
	}




	

}
