using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitializer : MonoBehaviour
{
    // Use this for initialization
    [System.Obsolete] //L10が旧型式の為追加
    void Start () {
        this.transform.position = -UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);
        
    }
	
	// Update is called once per frame
	[System.Obsolete]
    void Update () {
        Vector3 trackingPos = this.transform.position;
        var scale = transform.localScale;
        
    }
}
