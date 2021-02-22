using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStop : MonoBehaviour
{
    int counter;
    private ParticleSystem ps;
	// Use this for initialization
	void Start () {
        counter = 0;
        ps = this.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        counter++;
        if (counter == 120) { ps.Pause(); }
	}
}
