using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepZeroCameraRig : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 camerapos;
    void Start()
    {
        camerapos = this.gameObject.transform.position;
        this.gameObject.transform.position -= Vector3.Scale(camerapos, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position -= Vector3.Scale(this.gameObject.transform.position, Vector3.up);
    }
}
