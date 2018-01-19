using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodListItem
{
    /// <summary>
    /// 第1关:战争爆发
    /// </summary>
    public string GoodsName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 谈判失败，恼火的末日军团首领下令立即毁灭地球同盟。
    /// </summary>
    public string PicName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int Count { get; set; }
}

public class GoodsListModel
{
    /// <summary>
    /// 
    /// </summary>
    public List<GoodListItem> GoodList { get; set; }
}

public class TiShiModel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
