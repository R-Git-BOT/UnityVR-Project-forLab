using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class DataRecorder : MonoBehaviour
{
    public Transform camPos;
    //public GameObject randArray;


    private StreamWriter sw;
    private FileInfo fi;
    private int flameCounter;


    public void Start()
    {
        fi = new FileInfo("FileName.csv");
        sw = fi.AppendText();
        flameCounter = 0;
        sw.WriteLine("flame,xliner,yliner,zliner,xrotate,yrotate,zrotate");
    }

    public void FixedUpdate()
    {
        sw.WriteLine(flameCounter + "," + camPos.localPosition.x + "," + camPos.localPosition.y + ","+ camPos.localPosition.z + "," + camPos.localEulerAngles.x + "," + camPos.localEulerAngles.y + "," + camPos.localEulerAngles.z);
        flameCounter++;
    }

    public void OnApplicationQuit()
    {
        //sw.Flush();
        sw.Close();
    }
}
