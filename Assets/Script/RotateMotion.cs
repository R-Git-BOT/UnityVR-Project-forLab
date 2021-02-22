using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMotion : MonoBehaviour
{
    public float speed;
    public int x;
    public int y;
    public int z;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Rotate(new Vector3(speed*x,speed*y,speed*z));
	}
}
