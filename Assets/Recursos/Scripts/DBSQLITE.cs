using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class DBSQLITE : MonoBehaviour {

	// Use this for initialization

	public RectTransform panelA,panelB,panelC,panelD;
	private Image imgA,imgB,imgC,imgD;

	List<rgb> colores = new List<rgb>();
	void Start () {
		imgA = panelA.GetComponent<Image>();
		imgB= panelB.GetComponent<Image>();
		imgC = panelC.GetComponent<Image>();
		imgD = panelD.GetComponent<Image>();
		getcolor(conf_ini.a, imgA);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void colors(){
		string conn = "URI=file:" + Application.dataPath + "/Recursos/BD/bdcolor.db";
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open();
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "Select * from codigo" ;
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
			while(reader.Read()){
				rgb  data = new rgb();
				int id = reader.GetInt32(0);
				int r = reader.GetInt32(1);
				int g = reader.GetInt32(2);
				int b = reader.GetInt32(3);
				data.r = r;
				data.g = g;
				data.b = b; 
				colores.Add(data);
			}

			rgb c1 = colores[ Random.Range(0,colores.Count) ] ;
			rgb c2 = colores[ Random.Range(0,colores.Count) ] ;
			rgb c3 = colores[ Random.Range(0,colores.Count) ] ;
			rgb c4 = colores[ Random.Range(0,colores.Count) ] ;
			imgA.color = new Color(c1.r,c1.g,c1.b);
			imgB.color = new Color(c2.r,c2.g,c2.b);
			imgC.color = new Color(c3.r,c3.g,c3.b);
			imgD.color = new Color(c4.r,c4.g,c4.b);

		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
	}

	void sonido (){
				string conn = "URI=file:" + Application.dataPath + "/Recursos/BD/dbsonido.db";
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open();
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "Select sonido from sonido where id = 1" ;
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
			while(reader.Read()){
				byte[] son = (byte[])reader["sonido"];
            	Debug.Log(son);

				AudioSource audioSource = GetComponent<AudioSource>();
        		float[] samples = new float[audioSource.clip.samples * audioSource.clip.channels];
        		audioSource.clip.GetData(samples, 0);

        		for (int i = 0; i < samples.Length; ++i)
        		{
            		samples[i] = samples[i] * 0.5f;
        		}

        		audioSource.clip.SetData(samples, 0);

				 
			}

		
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();	
	}

		void getcolor(string nombre_color, Image panel){
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
