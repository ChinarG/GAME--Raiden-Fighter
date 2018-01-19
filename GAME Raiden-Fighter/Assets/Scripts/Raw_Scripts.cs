using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raw_Scripts : MonoBehaviour {

    public UILabel DengJi1;
    public UILabel DengJi2;
    public UILabel DengJi3;
    public UILabel DengJi4;
    public UILabel DengJi5;
    public UILabel DengJi6;
    public UILabel DengJi7;
    public UILabel DengJi8;
    public UILabel DengJi9;
    public GameObject[] DengJiXinXi;
    public TweenColor LEVEBG;
    int JiShu;

    void Start ()
    {
        LEVEBG = GameObject.Find("LEVEKuangBG").GetComponent<TweenColor>();
        LEVEBG.enabled = false;
        DengJi1 = GameObject.Find("DengJiA").GetComponent<UILabel>();
        DengJi2 = GameObject.Find("DengJiB").GetComponent<UILabel>();
        DengJi3 = GameObject.Find("DengJiC").GetComponent<UILabel>();
        DengJiXinXi = GameObject.FindGameObjectsWithTag("ZhanJiXinXiZhiA");

        DengJi7= DengJiXinXi[0].GetComponent<UILabel>();
        DengJi8 = DengJiXinXi[1].GetComponent<UILabel>();
        DengJi9 = DengJiXinXi[2].GetComponent<UILabel>();

        DengJi4 = DengJiXinXi[3].GetComponent<UILabel>();
        DengJi5 = DengJiXinXi[4].GetComponent<UILabel>();
        DengJi6 = DengJiXinXi[5].GetComponent<UILabel>();
       

        DengJi1.text = GameShengCheng.intancas.DengJiNumber.ToString();//输出 取出来的值
        DengJi3.text = GameShengCheng.intancas.DengJiNumber + "/30";
        if (GameShengCheng.intancas.DengJiNumber == 30)
        {
            DengJi2.text = "30";
        }
        else if (GameShengCheng.intancas.DengJiNumber < 30)
        {
            DengJi2.text = GameShengCheng.intancas.DengJiNumberhou.ToString();
        }

        if (GameShengCheng.intancas.JiaCheng == 92)
        {
            DengJi4.text = "100%";
            DengJi5.text = "100%";
            DengJi6.text = "100%";
            DengJi7.text = "100%"; ;
            DengJi8.text = "100%";
            DengJi9.text = "100%";
        }
        else if (GameShengCheng.intancas.JiaCheng < 92)
        {
            DengJi4.text = GameShengCheng.intancas.JiaCheng + "%";
            DengJi5.text = DengJi4.text;
            DengJi6.text = DengJi4.text;

            DengJi7.text = GameShengCheng.intancas.JiaCheng1 + "%";
            DengJi8.text = DengJi7.text;
            DengJi9.text = DengJi7.text;
        }

    }
	void Update ()
    {

        
    }
    /// <summary>
    /// 升级按钮方法
    /// </summary>
    public void ShengJiOnClick()
    {
        if (GameShengCheng.intancas.JiaCheng < 92)
        {
            if (GameShengCheng.intancas.DengJiNumber < 30)
            {
                StartCoroutine(ShengJiPrefab());//升级
                StartCoroutine(ChangeLEVEBG());

                GameShengCheng.intancas.DengJiNumber++;
                DengJi1.text = GameShengCheng.intancas.DengJiNumber.ToString();//输出 取出来的值
                GameShengCheng.intancas.DengJiNumberhou++;
                DengJi3.text = GameShengCheng.intancas.DengJiNumber + "/30";
                DengJi2.text = GameShengCheng.intancas.DengJiNumberhou.ToString();


                GameShengCheng.intancas.JiaCheng += 3;
                DengJi4.text = GameShengCheng.intancas.JiaCheng + "%";
                DengJi5.text = DengJi4.text;
                DengJi6.text = DengJi4.text;
                GameShengCheng.intancas.JiaCheng1 += 3;
                DengJi7.text = GameShengCheng.intancas.JiaCheng1 + "%";
                DengJi8.text = DengJi7.text;
                DengJi9.text = DengJi7.text;
            }
            if (GameShengCheng.intancas.JiaCheng == 92)
            {
                DengJi4.text = "100%";
                DengJi5.text = "100%";
                DengJi6.text = "100%";
                DengJi7.text = "100%"; ;
                DengJi8.text = "100%";
                DengJi9.text = "100%";
            }
            if (GameShengCheng.intancas.DengJiNumber == 30)
            {
                DengJi2.text = "30";
            }
        }
           
    }
    /// <summary>
    /// 升级框字体显示。
    /// </summary>
    /// <returns></returns>
    IEnumerator ShengJiPrefab()
    {
        GameObject registObj = Resources.Load<GameObject>("Prefabs/ShengJiTiShi");
        GameObject Kong = GameObject.Find("Shengjizuobiao");
        GameObject ClonePrefab = NGUITools.AddChild(Kong, registObj);
        yield return new WaitForSeconds(1);
        Destroy(ClonePrefab.gameObject);
    }
    IEnumerator ChangeLEVEBG()
    {
        LEVEBG.enabled = true;
        yield return new WaitForSeconds(0.8f);
        LEVEBG.enabled = false;
    }
}
