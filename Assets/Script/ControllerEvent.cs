using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;

public class ControllerEvent : MonoBehaviour
{
    public GameObject rollCam;  //LocalCameraTransform
    public Transform camPose; //カメラ参照 camposinit? camera?
    public GameObject recoder; //レコーダ
    public GameObject blackPanel; //パネル
    public Transform camPos;    //camPositonInit? camera?
    public SteamVR_ActionSet labaction;
    public SteamVR_Action_Boolean trigger_touch;    //トリガーが十分に引かれたら検知
    public SteamVR_Action_Boolean click_button;   //クリック検知
    private SteamVR_Input_Sources Handtype = SteamVR_Input_Sources.LeftHand;
    //Anyならどちらのコントローラーでも入力が取れる でもAnyでやったらバグったから気を付けて
    public SteamVR_Action_Vibration hapicAction = SteamVR_Input.GetAction<SteamVR_Action_Vibration>("Hapic");

    private bool act = true;
    private bool lockAct = false;
    private bool setup = false;
    private float deg;
    private int count = 0;
    private int maxCount;

    private bool inc = false;
    private bool dec = false;

    // Use this for initialization
    void Start () {
        Debug.Log("start");
        Invoke("delay", 0.4f);
        SteamVR_Actions.labaction.Activate(activateForSource: SteamVR_Input_Sources.Any, priority: 0, disableAllOtherActionSets: true);
    }

    // Update is called once per frame
    void Update()
    {
        SteamVR_TrackedObject trackedObject = GetComponent<SteamVR_TrackedObject>();
        if (setup)
        {
            //Debug.Log("inc is "+inc+", lockAct is "+lockAct+", dec is "+dec);
            //Debug.Log("Input: trigger "+Trigger_Touch.GetState(Handtype)+", Touchpad "+JoyStick_Click.GetState(Handtype));
            //ブラックアウトが消えるまで待機
            if (!act)   //!act
            {
                if (count < maxCount)
                {
                    blackPanel.GetComponent<blackOut>().changeAlpha(-0.02f);
                    
                    //Debug.Log("count is "+count+", maxCount is "+ maxCount);    //あとでコメントアウト
                    if (blackPanel.GetComponent<blackOut>().alfa < 0.0f)
                    {
                        lockAct = true;
                        act = true;

                        blackPanel.GetComponent<blackOut>().alfa = 0.0f;
                        //Debug.Log("black is under 0");

                    }
                }
            }   //ブラックアウトしていない・操作許可
            else if (lockAct)   //lockact
            {
                //Debug.Log("lockAct is true");
                //タッチイベント
                if (count < maxCount)
                {
                    //Debug.Log("input trigger or touchpad"); //あとでコメントアウト
                    if (trigger_touch.GetState(Handtype))
                    {
                        Debug.Log("トリガーを深く引いた");
                        Debug.Log("lower : deg = " + recoder.GetComponent<getRecorder>().randomArray[count] + ". count is " + count);
                        Debug.Log("head : deg = " + (360f - camPos.localEulerAngles.x).ToString());
                        recoder.GetComponent<getRecorder>().recodeData(recoder.GetComponent<getRecorder>().randomArray[count] + ",0," + (360f - camPos.localEulerAngles.x).ToString() +"\n");
                        //angles.Add(camPos.localEulerAngles.x.ToString());
                        lockAct = false;
                    }
                    if (click_button.GetState(Handtype))
                    {
                        Debug.Log("タッチパッドをクリックした");
                        Debug.Log("upward : deg = " + recoder.GetComponent<getRecorder>().randomArray[count] + ". count is " + count);
                        Debug.Log("head : deg = " + (360f - camPos.localEulerAngles.x).ToString());
                        recoder.GetComponent<getRecorder>().recodeData(recoder.GetComponent<getRecorder>().randomArray[count] + ",1," + (360f - camPos.localEulerAngles.x).ToString() + ",\n");
                        //angles.Add(camPos.localEulerAngles.x.ToString());
                        lockAct = false;
                    }    
                }
            }   //ブラックアウトしカメラ回転
            else if (!lockAct)  //!lockact
            {
                //Debug.Log("lockAct is false");
                blackPanel.GetComponent<blackOut>().changeAlpha(0.02f);
                
                if (blackPanel.GetComponent<blackOut>().alfa > 2.0f)
                {
                    //Debug.Log("alpha is over 2");
                    act = false;
                    lockAct = false;
                    blackPanel.GetComponent<blackOut>().alfa = 1.0f;
                    //camPose.position = new Vector3(0, -0.8f, Random.Range(0f, 200f));
                    camPose.position = new Vector3(0, 0, Random.Range(0f, 200f));
                    count++;
                    
                    if (count < maxCount) {
                        rollCam.GetComponent<startRotation>().StartRotate(recoder.GetComponent<getRecorder>().randomArray[count]);
                    } else {
                        Debug.Log("END");
                    }
                }
            }
        }
    }

    public void delay()
    {
        maxCount = recoder.GetComponent<getRecorder>().randomArray.Count;
        Debug.Log("maxcount is " + maxCount);
        rollCam.GetComponent<startRotation>().StartRotate(recoder.GetComponent<getRecorder>().randomArray[count]);
        Debug.Log("complete setup");
        Debug.Log("head : deg = " + (360f - camPos.localEulerAngles.x).ToString());
        act = false;
        lockAct = true;
        setup = true;
        inc = false;
        dec = true;
    }

    public void ControllerHaptic()
    {
        float seconds = 3000f / 1000000f;
        hapicAction.Execute(0, seconds, 1f / seconds, 1, Handtype);
    }
}
