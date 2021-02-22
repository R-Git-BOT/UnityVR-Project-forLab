using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAhead : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Timemanagerを開いて設定する
    void FixedUpdate()
    {
        this.transform.Translate(xSpeed, ySpeed, zSpeed, Space.World);
    }
}
