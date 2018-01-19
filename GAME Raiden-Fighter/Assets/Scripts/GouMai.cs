using UnityEngine;
using System.Collections;

public class GouMai : MonoBehaviour
{
    public GameObject ShangDain;
    public GameObject MaiDongXiJieGuo;

	// Use this for initialization
	void Start ()
    {
        
        ShangDain.SetActive(true);
        MaiDongXiJieGuo.SetActive(false);
	
	}

    public void OnClickMaiDongXi()
    {
        StartCoroutine(MaiDongXi());
    }
    IEnumerator MaiDongXi()
    {
        ShangDain.SetActive(false);
        MaiDongXiJieGuo.SetActive(true);
        yield return new WaitForSeconds(2f);
        ShangDain.SetActive(true);
        MaiDongXiJieGuo.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
    //public void AAAAAA()
    //{
    //    GameObject AA = Resources.Load<GameObject>("Prefabs/GouMaiShiBai ");
    //    GameObject FU = GameObject.Find("ZhanHuanJieMian");
    //    GameObject OBJ = NGUITools.AddChild(FU, AA);
    //}
}
