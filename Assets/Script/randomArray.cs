using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomArray : MonoBehaviour
{
    public int min = 0;
    public int max = 20;
    public bool mix = true;
    public bool ascsort = false;
    public bool dessort = false;
    public List<int> array = new List<int>();
    
    private int arrayRange;
    private int temp;
    private int rand;

	// Use this for initialization
	void Start () {
        arrayRange = (max - min) /  2 + 1;
	    for(int i = 0; i < arrayRange; i++)
        {
            array.Add(min + i * 2); //2ずつ足す
           // Debug.Log(i);
        }
        Debug.Log(array.Count);
        max = array[array.Count - 1];
        if (mix)
        {   //Mix（混ぜる？）変数がTrueの時シャッフル
            for (int i = 0; i < array.Count; i++)
            {
                rand = Random.Range(0, array.Count);
                temp = array[rand];
                array[rand] = array[i];
                array[i] = temp;
                Debug.Log(temp);
            }
        }
        
        if (ascsort)
        {
            array.Sort();   //ランダムにした配列を戻す
        }

        if (dessort)
        {
            array.Sort();
            array.Reverse();    //ランダムにした配列を逆順にする
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
