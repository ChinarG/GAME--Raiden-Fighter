using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQiaYu : MonoBehaviour {


	void Start () {
		
	}

	void Update () {
		
	}
    public void PassOnClick()
    {
        StartCoroutine(ShanChuPrefab());
    }
    IEnumerator ShanChuPrefab()
    {
        GameObject registObj = Resources.Load<GameObject>("Prefabs/GuanQiaTiShi");
        GameObject Kong = GameObject.Find("TiShiZuoBiao");
        GameObject ClonePrefab = NGUITools.AddChild(Kong, registObj);
        yield return new WaitForSeconds(2);
        Destroy(ClonePrefab.gameObject);
    }
}
