using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using LitJson;
using UnityEditor;

public class DaoJuShangDian : MonoBehaviour
{
    public GameObject Grids;

    public List<GameObject> cellList = new List<GameObject>();

    GoodsListModelOne goodsListModelYi;

    // Use this for initialization
    void Start ()
    {
        XianShi();
        AddTuPian();

    }
    private void XianShi()
    {
        //Grids = GameObject.Find("Grid");

        for (int i = 0; i < 3; i++)
        {
            GameObject WeiShiLiHua = Resources.Load<GameObject>("Prefabs/WuPin");
            GameObject NGUIOBJ = NGUITools.AddChild(this.gameObject, WeiShiLiHua);
            UILabel label = NGUIOBJ.transform.Find("JiaQian").GetComponent<UILabel>();
            label.enabled = false;

            UILabel label1 = NGUIOBJ.transform.Find("ZhongLei").GetComponent<UILabel>();
            label1.enabled = false;

            UILabel label2 = NGUIOBJ.transform.Find("ShuoMing/JieShi").GetComponent<UILabel>();
            label2.enabled = false;

            cellList.Add(NGUIOBJ);
        }
        GetComponent<UIGrid>().enabled = true;
    }
    private void AddTuPian()
    {
        UIAtlas TuPianAtlas = Resources.Load<UIAtlas>("Atlas/TuPian");
        for (int i = 0; i < ReadPakgeInfo().GoodList.Count; i++)
        {
            string spriteName = ReadPakgeInfo().GoodList[i].PicNameOne;
            UISprite sprite = NGUITools.AddSprite(cellList[i], TuPianAtlas, spriteName);
            UILabel label = cellList[i].transform.Find("JiaQian").GetComponent<UILabel>();
            label.text = ReadPakgeInfo().GoodList[i].CountOne.ToString();
            label.enabled = true;
            sprite.width = 180;
            sprite.height = 180;

            UILabel label1 = cellList[i].transform.Find("ZhongLei").GetComponent<UILabel>();
            label1.text = ReadPakgeInfo().GoodList[i].GoodsNameOne.ToString();
            label1.enabled = true;

            UILabel label2 = cellList[i].transform.Find("ShuoMing/JieShi").GetComponent<UILabel>();
            label2.text = ReadPakgeInfo().GoodList[i].IDOne.ToString();
            label2.enabled = true;

        }
    }
    private GoodsListModelOne ReadPakgeInfo()
    {
        //声明一个文本接收PakgeInfo
        TextAsset textAsset = Resources.Load<TextAsset>("Json/PakgeInfoOne");

        if (!textAsset)
        {
            return null;

        }
        goodsListModelYi = JsonMapper.ToObject<GoodsListModelOne>(textAsset.text);

        return goodsListModelYi;

    }

    bool Daoju = false;
    public void OnClickJu(GameObject obj)
    {
        TweenScale scale = obj.GetComponentInChildren<TweenScale>();
        if (!Daoju)
        {

            scale.enabled = true;
            scale.PlayForward();
            Daoju = true;

        }
        else
        {
            Daoju = false;
            scale.PlayReverse();
        }
    }
    // Update is called once per frame
    void Update ()
    {
	
	}
}
