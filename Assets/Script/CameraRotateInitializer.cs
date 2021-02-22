using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateInitializer : MonoBehaviour
{
    public Transform cube;
    
	void Start () {
        //startのタイミングで動かすと、トラッキングの場所などとかち合うため、遅延処理
        Invoke("CameraRotateInitialize", 0.1f);
    }

    //
    //回転方向をトラッキングして打ち消す方向に回す
    [System.Obsolete] //L17が旧型式の為追加
    void CameraRotateInitialize()
    {
        //-UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).eulerAngles
        Debug.Log(UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).eulerAngles);
        this.transform.Rotate(-UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).eulerAngles.x,-UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).eulerAngles.y,0);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        cube.rotation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye);
    }
}
