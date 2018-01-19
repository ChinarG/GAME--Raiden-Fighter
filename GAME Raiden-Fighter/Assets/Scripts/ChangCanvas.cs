using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangCanvas : MonoBehaviour {

    public GameObject[] Canvas;

	// Use this for initialization
	void Start () {
        Changcanvas(0);

    }
	
	// Update is called once per frame
	void Update () {


    }

     void Changcanvas(int index)
    {
        for (int i = 0; i < Canvas.Length; i++)
        {
            GameObject obj = Canvas[i];
            if(i == index)
            {
                obj.SetActive(true);


            }
            else
            {

                obj.SetActive(false);

            }
        }


    }

    public void login()
    {
        Changcanvas(0);
        
    }
    public void regist()
    {
        Changcanvas(1);
        
    }
    public void QQ()
    {
        Changcanvas(2);

    }
}
