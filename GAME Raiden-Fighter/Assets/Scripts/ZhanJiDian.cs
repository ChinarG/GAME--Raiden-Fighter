using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using LitJson;
using UnityEditor;

public class ZhanJiDian : MonoBehaviour
{
    public GameObject Grids;

    public List<GameObject> cellList = new List<GameObject>();

    GoodsListModelOne goodsListModel;

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
            GameObject WeiShiLiHua = Resources.Load<GameObject>("Prefabs/JiXing");
            GameObject NGUIOBJ = NGUITools.AddChild(this.gameObject, WeiShiLiHua);
            UILabel label = NGUIOBJ.transform.Find("JiaGe").GetComponent<UILabel>();
            label.enabled = false;

            UILabel label1 = NGUIOBJ.transform.Find("MingZi").GetComponent<UILabel>();
            label1.enabled = false;

            UILabel label2 = NGUIOBJ.transform.Find("JieShao/NeiRong").GetComponent<UILabel>();
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
            string spriteName = ReadPakgeInfo().GoodList[i].PicName;
            UISprite sprite = NGUITools.AddSprite(cellList[i], TuPianAtlas, spriteName);
            UILabel label = cellList[i].transform.Find("JiaGe").GetComponent<UILabel>();
            label.text = ReadPakgeInfo().GoodList[i].Count.ToString();
            label.enabled = true;
            sprite.width = 180;
            sprite.height = 180;

            UILabel label1 = cellList[i].transform.Find("MingZi").GetComponent<UILabel>();
            label1.text = ReadPakgeInfo().GoodList[i].GoodsName.ToString();
            label1.enabled = true;

            UILabel label2 = cellList[i].transform.Find("JieShao/NeiRong").GetComponent<UILabel>();
            label2.text = ReadPakgeInfo().GoodList[i].ID.ToString();
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
        goodsListModel = JsonMapper.ToObject<GoodsListModelOne>(textAsset.text);

        return goodsListModel;

    }

    bool isShowAlter = false;
    public void OnClickJi(GameObject obj)
    {
        TweenScale scale = obj.GetComponentInChildren<TweenScale>();

        if (!isShowAlter)
        {

            scale.enabled = true;
            scale.PlayForward();
            isShowAlter = true;

        }
        else
        {
            isShowAlter = false;
            scale.PlayReverse();
        }
    }
    // Update is called once per frame
    void Update ()
    {
	
	}
}
