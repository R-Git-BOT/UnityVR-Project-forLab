using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


public class getRecorder : MonoBehaviour
{
    public GameObject rand;
    public bool fomula;
    public bool sedan;
    public bool onebox;
    public bool track;
    private int shiten;
    public GameObject chikei;
    public String subject = "name"; //name
    private bool Standing = false;
    private bool Supine = false;
    private bool Reclining = true;
    public float ReclinDeg = 0;

    private String posture = "";
    private String fileName;
    private StreamWriter sw;
    private FileInfo fi;
    private String month;
    private String day;
    private String hour;
    private String minute;
    private String fullPath;
    private String higher;
    public List<int> randomArray = new List<int>();

    public void Start()
    {
        if (Standing)
        {
            posture = "Stand";
        }
        else if (Supine)
        {
            posture = "Supine";
        }
        else if (Reclining)
        {
            posture = "Recline";
        }
        else
        {
            Debug.LogWarning("姿勢が選択されていません");
        }
        if(fomula){
            shiten = 50;
        }else if(sedan){
            shiten = 120;
        }else if(onebox){
            shiten = 180;
        }else if(track){
            shiten = 240;
        }else{
            Debug.LogWarning("視点が選択されていません");
            shiten = 0;
        }
        chikei.transform.position -=  Vector3.up * shiten / 100;

        month = addDigit(System.DateTime.Now.Month);
        day = addDigit(System.DateTime.Now.Day);
        hour = addDigit(System.DateTime.Now.Hour);
        minute = addDigit(System.DateTime.Now.Minute);
        higher = shiten.ToString();

        Debug.Log(subject + " starts experiment in " + System.DateTime.Now.ToString() + " on " + higher);

        fullPath = Path.GetFullPath("csv");
        
        fileName = month + day + hour + minute + "_" + subject + "_" + posture + "_" + ReclinDeg + "_" + shiten.ToString() + ".csv";
        Debug.Log(fullPath+"\\"+fileName);
        Invoke("delay", 0.2f);
    }

    public void FixedUpdate()
    {
       // Debug.Log(randArray.GetComponent<randomArray>().array[0]);
    }

    public void OnApplicationQuit()
    {
        sw.Flush();
        sw.Close();
    }
    public void delay()
    {
        fi = new FileInfo(fullPath+"\\"+fileName);
        if (!fi.Exists) 
        {
            fi = new FileInfo(fullPath+"\\"+fileName+"_1");
        }
        sw = fi.AppendText();
        for (int i = 0; i < rand.GetComponent<randomArray>().array.Count; i++)
        {
            //データの配列を入れる
            randomArray.Add(rand.GetComponent<randomArray>().array[i]);
        }
        // ファイル出力しない場合は ここから
        /* 
        for (int i = 0; i < randomArray.Count; i++)
        {
            sw.Write(randomArray[i]);
            sw.Write(",");
            Debug.Log(randomArray[i]);
        }
        sw.Write("\n"); */
        //ここまでコメントアウト
    }

    public void recodeData(String data)
    {
        //getrecorder.randomArray[count],0or1,hedDeg がDataとして贈られる
        Debug.Log(data);
        sw.Write(data);
        //sw.Write(",");
    }

    private String addDigit(int numb)
    {
        if (numb < 10)
        {
            return "0" + numb.ToString();
        }
        else
        {
            return numb.ToString();
        }
    }

    internal void recodeData(Func<string> toString)
    {
        throw new NotImplementedException();
    }
}
