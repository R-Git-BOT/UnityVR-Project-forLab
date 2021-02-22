using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blackOut : MonoBehaviour
{
    // Start is called before the first frame update
    public float alfa = 1.0f;
    public bool action = true;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (action)
        {
            this.GetComponent<Image>().color = new Color(0f, 0f, 0f, alfa);
            //Debug.Log("Alpha : "+alfa);
        }
        
	}

    public void changeAlpha(float add){
        alfa += add;
        //Debug.Log("Alpha changed. added "+ add +". now => "+ alfa);
    }
}
