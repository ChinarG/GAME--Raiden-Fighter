using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using UnityEngine.SceneManagement;
public class GameShengCheng : MonoBehaviour
{
    /// <summary>
    /// 单例
    /// </summary>
    public static GameShengCheng intancas;
    public void Awake()
    {
        if (intancas != null)
        {
            Destroy(intancas);
        }
        else
        {
            intancas = this;
        }
    }

    public int DengJiNumber;
    public int DengJiNumberhou;
    public int JiaCheng;
    public int JiaCheng1;

    public int ShiJian1 = 60;
    public float totalTime = 0;
    public int Daojishi1 = 4;
    public UILabel WuFenZhong;
    public UILabel TiLi;
    public int TiLiShu = 50;
    public int TiLiMax = 100;
    TweenColor XianTiao1;
    int Tt;
    public UILabel Guanqia;
    public UILabel GuanqiaJieShao;
    GoodsListModel goodsListModel;
    public List<GameObject> CellList = new List<GameObject>();
    public int shuzi;
    public GameObject ShiJianJieMian;
    /// <summary>
    /// 初始化数据；
    /// </summary>
    void Start()
    {
        DengJiNumber = 1;
        DengJiNumberhou = 2;
        JiaCheng = 5;
        JiaCheng1 = 8;
        Tt = 0;
        shuzi = 0;
        ChangePage(1);
        GameObject Obj = Resources.Load<GameObject>("Prefabs/UI Root");
    }
    void Update()
    {
        ShiJianJieMian = GameObject.Find("GuanQia");
        if (ShiJianJieMian != null)
        {
            WuFenZhong = GameObject.Find("5FenZhong").GetComponent<UILabel>();
            TiLi = GameObject.Find("TiLi").GetComponent<UILabel>();
            if (TiLiShu < 100)
            {
                Daojishi5fenzhong();
            }
            else if (TiLiShu >= 100)
            {
                WuFenZhong.text = "05:00";
            }
            else if (TiLiShu < 0)
            {
                TiLiShu = 0;
            }
        }



    }
    /// <summary>
    /// 机型选择——注册界面；
    /// </summary>
    public void JiXing_DengLu()
    {
        ChangePage(1);
    }
    /// <summary>
    /// 机型选择——关卡界面；
    /// </summary>
    public void JiXing_GuanQia()
    {
        ChangePage(2);
        ChangePage(4);
    }
    /// <summary>
    /// 关卡界面——机型选择；
    /// </summary>
    public void GuanQia_JiXing()
    {
        ChangePage(1);
        GameObject shandiao = GameObject.Find("GuanQia(Clone)");
        Destroy(shandiao.gameObject);
    }
    /// <summary>
    /// 关卡界面——提示是否开始；
    /// </summary>
    public void TIShi()
    {
        ChangePage(3);
    }
    /// <summary>
    /// 关闭提示页面按钮方法
    /// </summary>
    public void TrunOffTIShi()
    {
        GameObject shandiao = GameObject.Find("TIShiBG(Clone)");
        Destroy(shandiao.gameObject);
    }
    /// <summary>
    /// 跳转页面
    /// </summary>
    /// <param 跳转小标="index"></param>
    private void ChangePage(int index)
    {
        if (index == 1)
        {
            ShanChuPrefab("Prefabs/Raw_image", "UI Root");
        }
        else if (index == 2)
        {
            GameObject shandiao = GameObject.Find("Raw_image(Clone)");
            Destroy(shandiao.gameObject);
            ShanChuPrefab("Prefabs/GuanQia", "UI Root");
        }
        else if (index == 3)
        {
            ShanChuPrefab("Prefabs/TIShiBG", "UI Root");
        }
        else if (index == 4)
        {
            ShanChuPrefab("Prefabs/GD", "UI Root");
            GameObject shandiao = GameObject.Find("GD(Clone)");
            Destroy(shandiao.gameObject, 2f);
        }
    }
    /// <summary>
    /// 加载预设页面，到屏幕中；
    /// </summary>
    /// <param 预设物名字="PrefabName"></param>
    /// <param 所加入的父物体="FindName"></param>
    /// <returns></returns>
    private void ShanChuPrefab(string PrefabName, string FindName)
    {
        GameObject Obj = Resources.Load<GameObject>(PrefabName);
        GameObject Kong = GameObject.Find(FindName);
        GameObject ObjPrefab = NGUITools.AddChild(Kong, Obj);
    }
    /// <summary>
    /// 绑定写入Json——Label的方法
    /// </summary>
    /// <param 形参="XIA"></param>
    public void BangDing(int XIA)
    {
        ChangePage(3);
        Guanqia = GameObject.Find("GuanQiaName").GetComponent<UILabel>();
        GuanqiaJieShao = GameObject.Find("GuanQiaJieShao").GetComponent<UILabel>();
        string Guanqia1 = ReadPakgeInfo().GoodList[XIA].GoodsName;//类里的数组的名字；
        Guanqia.text = Guanqia1;
        string GuanqiaJieShao1 = ReadPakgeInfo().GoodList[XIA].PicName;
        GuanqiaJieShao.text = GuanqiaJieShao1;

    }
    /// <summary>
    /// //读取JSON返回一个数组类
    /// </summary>
    /// <returns></returns>
    private GoodsListModel ReadPakgeInfo()
    {
        TextAsset _textAsset = Resources.Load<TextAsset>("Json/PakgeInfo");

        if (!_textAsset)
        {
            return null;
        }
        goodsListModel = JsonMapper.ToObject<GoodsListModel>(_textAsset.text);
        return goodsListModel;
    }


    /// <summary>
    /// 按钮方法，传入2个GameObject值；
    /// </summary>
    /// <param 按钮="col"></param>
    /// <param 修改的线条颜色="col1"></param>
    public void DDDDDD(GameObject col, GameObject col1)
    {
        for (int i = 0; i < 7; i++)
        {
            if (col.name == "shuijing" + i)
            {
                BangDing(i);
                if (i == 0)
                {
                    break;
                }
            }
            if (i < 5)
            {
                if (col1.name == "XT" + i)
                {
                    XianTiao1 = col1.GetComponent<TweenColor>();
                    XianTiao1.enabled = true;
                }
            }
        }
    }
    /// <summary>
    /// 倒计时；
    /// </summary>
    public void Daojishi5fenzhong()
    {
        //累加每帧消耗时间
        totalTime += Time.deltaTime;
        if (totalTime >= 1)//每过1秒执行一次
        {
            ShiJian1--;

            if (ShiJian1 < 0)
            {
                Daojishi1--;
                ShiJian1 = 59;
            }
            if (Daojishi1 < 0)
            {
                print(22);
                Daojishi1 = 4;
            }
            if (ShiJian1 == 59)
            {
                WuFenZhong.text = "0" + Daojishi1 + ":00";
            }
            WuFenZhong.text = "0" + Daojishi1 + ":" + ShiJian1;
            if (ShiJian1 < 10)
            {
                WuFenZhong.text = "0" + Daojishi1 + ":0" + ShiJian1;
            }

            totalTime = 0;

            AddTiLi();
        }
    }
    /// <summary>
    /// 增加体力；
    /// </summary>
    private void AddTiLi()
    {
        if (ShiJian1 == 0 && Daojishi1 == 0)
        {
            TiLiShu++;

            if (TiLiShu > 100)
            {
                TiLiShu = 100;
            }
            TiLi.text = TiLiShu + "/" + TiLiMax;
        }
    }
    public void ShangDian()
    {
        SceneManager.LoadScene("ZhanJi");
    }
}
