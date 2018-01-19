using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GoodListItemOne
{
    /// <summary>
    /// 雷电1号
    /// </summary>
    public string GoodsName { get; set; }
    /// <summary>
    /// 全能型飞机作战能力强
    /// </summary>
    public string ID { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string PicName { get; set; }
    /// <summary>
    /// 1000宝石
    /// </summary>
    public string Count { get; set; }
    /// <summary>
    /// 必杀技能
    /// </summary>
    public string GoodsNameOne { get; set; }
    /// <summary>
    /// 对屏幕的所有敌机进行击杀
    /// </summary>
    public string IDOne { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string PicNameOne { get; set; }
    /// <summary>
    /// 500宝石
    /// </summary>
    public string CountOne { get; set; }
    /// <summary>
    /// 雷火战神
    /// </summary>
    public string GoodsNameTwo { get; set; }
    /// <summary>
    /// 升成此机攻击+50%,经验+20%,宝石+10% 
    /// </summary>
    public string IDTwo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string PicNameTwo { get; set; }
    /// <summary>
    /// 100000宝石
    /// </summary>
    public string CountTwo { get; set; }
}

public class GoodsListModelOne
{
    /// <summary>
    /// 
    /// </summary>
    public List<GoodListItemOne> GoodList { get; set; }
}
public class ZhanJiJson : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
