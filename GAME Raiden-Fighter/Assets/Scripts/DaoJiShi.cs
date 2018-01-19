using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DaoJiShi : MonoBehaviour
{

    public int ShiJian1 = 60;
    public float totalTime = 0;
    public int Daojishi1 = 4;
    public UILabel WuFenZhong;
    public UILabel TiLi;
    public int TiLiShu=50;
    public int TiLiMax=100;
    void Start ()
    {
        WuFenZhong = GameObject.Find("5FenZhong").GetComponent<UILabel>();
        TiLi = GameObject.Find("TiLi").GetComponent<UILabel>();
    }
	void Update ()
    {
        if (TiLiShu<100)
        {
            Daojishi5fenzhong();
        }
        else if (TiLiShu>=100)
        {
            WuFenZhong.text = "05:00";
        }
        else if (TiLiShu<0)
        {
            TiLiShu = 0;
        }
    }



    private void Daojishi5fenzhong()//倒计时
    {
        //累加每帧消耗时间
        totalTime += Time.deltaTime;
        if (totalTime >= 1)//每过1秒执行一次
        {
            ShiJian1--;

            if (ShiJian1<0)
            {
                Daojishi1 -- ;
                ShiJian1 = 59;
            }
            if (Daojishi1 <0)
            {
                print(22);
                Daojishi1 = 4;
            }
            if (ShiJian1 == 59)
            {
                WuFenZhong.text ="0"+ Daojishi1 + ":00";
            }
            WuFenZhong.text = "0" + Daojishi1 + ":" + ShiJian1;
            if (ShiJian1<10)
            {
                WuFenZhong.text = "0" + Daojishi1 + ":0" + ShiJian1;
            }

            totalTime = 0;

            AddTiLi();
        }
    }
    private void AddTiLi()
    {
        if (ShiJian1==0&&Daojishi1==0)
        {
            TiLiShu++;
            
            if (TiLiShu>100)
            {
                TiLiShu = 100;
            }
            TiLi.text = TiLiShu + "/" + TiLiMax;
        }
    }
}
