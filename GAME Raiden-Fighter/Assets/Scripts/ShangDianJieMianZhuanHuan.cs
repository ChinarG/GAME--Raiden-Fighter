using UnityEngine;
using System.Collections;

public class ShangDianJieMianZhuanHuan : MonoBehaviour
{
    public GameObject[] Canvass;
    // Use this for initialization
    void Start ()
    {
        ChangCanvass(0);

    }
    public void OnClickZhangJi()
    {
        ChangCanvass(0);

    }
    public void OnClickDaoJu()
    {
        ChangCanvass(1);
        
    }
    public void OnClickShengJi()
    {
        ChangCanvass(2);

    }
    public void ChangCanvass(int index)
    {
        for (int i = 0; i < Canvass.Length; i++)
        {
            GameObject obj = Canvass[i];
            Time.timeScale = 1;

            if (i == index)
            {
                obj.SetActive(true);

            }
            else
            {
                obj.SetActive(false);
            }

        }
    }
    // Update is called once per frame
    void Update ()
    {
	
	}
}
