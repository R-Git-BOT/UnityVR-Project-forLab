using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startRotation : MonoBehaviour
{
    public int xMin;
    public int xMax;

    int deg;


    // Use this for initialization
    void Start()
    {
        /*
        deg = Random.Range(xMin, xMax);
        deg /= 2;
        deg *= 2;
        Debug.Log(deg);
        this.transform.Rotate(new Vector3(deg, 0, 0));
        */
    }

    public void StartRotate(float deg)
    {
        this.transform.localEulerAngles = new Vector3(0, 0, 0);
        /*
        deg = Random.Range(xMin, xMax);
        deg /= 2;
        deg *= 2;
        Debug.Log(deg);
        */
        this.transform.Rotate(new Vector3(deg, 0, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
