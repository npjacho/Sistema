using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class BASICOA_JUGABILIDAD : MonoBehaviour {

    public RectTransform panelA, panelB;
    private Image imgA, imgB;
    public AudioSource audioUbicacion;
    public AudioClip donde_esta,audio_personaje_1,audio_personaje_2;

    public GameObject btnMsg;
    public Button btn_izquierda;
    private Texture2D texturaIzquierda;
    public Button btn_derecha;
    private Texture2D texturaDerecha;
    rgb colorIzq = new rgb ();
    rgb colorDer = new rgb ();
    private int codigo_detalle_aprendizaje_1 = 27 ;// LOGIN_JUGABILIDAD.codigosBasicoA.ElementAt(0);
    private int codigo_detalle_aprendizaje_2 = 28 ; //LOGIN_JUGABILIDAD.codigosBasicoA.ElementAt(1);


    // Use this for initialization
    void Start () {
        btnMsg.SetActive (false);
        Debug.Log (codigo_detalle_aprendizaje_1);
        Debug.Log (codigo_detalle_aprendizaje_2);
        imgA = panelA.GetComponent<Image> ();
        imgB = panelB.GetComponent<Image> ();
        obtenerDatos1(codigo_detalle_aprendizaje_1);
        obtenerDatos2(codigo_detalle_aprendizaje_2);
       

    }


    // Update is called once per frame
    void Update () {
        
    }

    public void siguienteElemento(){

    }

    //colores guardados.
    private void obtenerDatos1 (int id) {
        Debug.Log("funcion con id " + id);
        texturaIzquierda = new Texture2D (256, 256);
        byte[] son = new byte[0];
        byte[] imagen_personaje = new byte[0];
        string conn = "URI=file:" + Application.dataPath + "/Recursos/BD/dbdata.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection (conn);
        dbconn.Open ();
        IDbCommand dbcmd = dbconn.CreateCommand ();
        string sqlQuery;
        
        sqlQuery = "select t2.r_color, t2.g_color, t2.b_color, t3.audio_personaje, t3.imagen_personaje from detalle_aprendizaje as t1 inner join color as t2 on t2.id = t1.id_color inner join personaje as t3 on t1.id_personaje = t3.id_personaje where t1.id_detalle_apre = " + id;
        //"select color.r_color, color.g_color, color.b_color, ubicacion.nombre_ubicacion, tpersonaje.audio_personaje, tpersonaje.imagen_personaje from detalle_aprendizaje  as detalle_aprendizaje inner join color on color.id = id_color inner join ubicacion on ubicacion.id = id_ubicacion inner join personaje as tpersonaje on tpersonaje.id_personaje = detalle_aprendizaje.id_personaje where id_detalle_apre = " + id;
        Debug.Log (sqlQuery);
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader ();
        while (reader.Read ()) {
            colorIzq.r = reader.GetInt32 (0);
            colorIzq.g = reader.GetInt32 (1);
            colorIzq.b = reader.GetInt32 (2);
            son = (byte[]) reader["audio_personaje"];
            imagen_personaje = (byte[]) reader["imagen_personaje"];
        }
        Debug.Log(colorIzq.r);
        WAV sonido = new WAV (son);
        audio_personaje_1 = AudioClip.Create("personaje_1",sonido.SampleCount, 1, sonido.Frequency, false,false);
        audio_personaje_1.SetData(sonido.LeftChannel,0);
        texturaIzquierda.LoadImage(imagen_personaje);
        reader.Close ();
        reader = null;
        dbcmd.Dispose ();
        dbcmd = null;
        dbconn.Close ();
        Debug.Log("Ya salio de la base de datos");
          StartCoroutine (playsound ());
    }
        private void obtenerDatos2 (int id) {
        texturaDerecha = new Texture2D (256, 256);
        byte[] son = new byte[0];
        byte[] imagen_personaje = new byte[0];
        string conn = "URI=file:" + Application.dataPath + "/Recursos/BD/dbdata.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection (conn);
        dbconn.Open ();
        IDbCommand dbcmd = dbconn.CreateCommand ();
        string sqlQuery;
        sqlQuery = "select t2.r_color, t2.g_color, t2.b_color, t3.audio_personaje, t3.imagen_personaje from detalle_aprendizaje as t1 inner join color as t2 on t2.id = t1.id_color inner join personaje as t3 on t1.id_personaje = t3.id_personaje where t1.id_detalle_apre = " + id;
        Debug.Log (sqlQuery);
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader ();
        while (reader.Read ()) {
            colorDer.r = reader.GetInt32 (0);
            colorDer.g = reader.GetInt32 (1);
            colorDer.b = reader.GetInt32 (2);
            son = (byte[]) reader["audio_personaje"];
            imagen_personaje = (byte[]) reader["imagen_personaje"];
        }
         WAV sonido = new WAV (son);
        audio_personaje_2 = AudioClip.Create("personaje_2",sonido.SampleCount, 1, sonido.Frequency, false,false);
        audio_personaje_2.SetData(sonido.LeftChannel,0);
        texturaDerecha.LoadImage(imagen_personaje);
        reader.Close ();
        reader = null;
        dbcmd.Dispose ();
        dbcmd = null;
        dbconn.Close ();
        
    }

    public void interaccionPanelA(){
        imgA.color = new Color(colorIzq.r,colorIzq.g,colorIzq.b); 
    }
    public void interaccionPanelASalir(){
        imgA.color = new Color(0,0,0); 
    }

    public void interccionPanelB(){
        imgB.color = new Color(colorDer.r,colorDer.g,colorDer.b); 
    }
    public void interccionPanelBSalir(){
        imgB.color = new Color(0,0,0); 
    }

    public void VerPersonaje1(){
        btn_izquierda.GetComponent<Image>().sprite = Sprite.Create(texturaIzquierda, new Rect(0,0,256,256), new Vector2(0.5f,0.5f));
    }

    public void VerPersonaje2(){
        btn_derecha.GetComponent<Image>().sprite = Sprite.Create(texturaDerecha, new Rect(0,0,256,256), new Vector2(0.5f,0.5f));
    }

    public void botonderecho(){
        Debug.Log("Toque el boton");
        btn_derecha.GetComponent<Renderer>().material.color = Color.red;
     
    }

    public void botonderechoSalir(){
       
    }

    IEnumerator playsound () {
        Debug.Log ("reproducuiendo......");
        audioUbicacion.clip = donde_esta;
        audioUbicacion.Play ();
        yield return new WaitForSeconds (audioUbicacion.clip.length);
        audioUbicacion.clip = audio_personaje_1;
        audioUbicacion.Play ();
    }

    IEnumerator playsound2 () {
        Debug.Log ("reproducuiendo......");
        audioUbicacion.clip = donde_esta;
        audioUbicacion.Play ();
        yield return new WaitForSeconds (audioUbicacion.clip.length);
        audioUbicacion.clip = audio_personaje_2;
        audioUbicacion.Play ();
    }

}