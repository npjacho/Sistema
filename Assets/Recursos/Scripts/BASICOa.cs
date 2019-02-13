using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class BASICOa : MonoBehaviour {
	public RectTransform panelA,panelB;
	private Image imgA,imgB;
	// Use this for initialization
	void Start () {
		imgA = panelA.GetComponent<Image>();
		imgB= panelB.GetComponent<Image>();
		colors(conf_ini.a, imgA);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

		void colors(string nombre_color, Image panel){
		rgb  data = new rgb();
		string conn = "URI=file:" + Application.dataPath + "/Recursos/BD/dbdata.db";
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open();
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "Select * from color where nombre_color = '" + nombre_color + "'" ;
		Debug.Log(sqlQuery);
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
			while(reader.Read()){
				//int id = reader.GetInt32(0);
				int r = reader.GetInt32(3);
				int g = reader.GetInt32(5);
				int b = reader.GetInt32(4);
				data.r = r;
				data.g = g;
				data.b = b; 
		}
			panel.color = new Color(data.r,data.g,data.b);

		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
	}
}
