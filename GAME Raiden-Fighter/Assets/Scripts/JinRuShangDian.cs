using UnityEngine;
using System.Collections;

public class JinRuShangDian : MonoBehaviour
{
    public GameObject Cheng;
    public GameObject JinRu;
    public GameObject Goumai;
    public GameObject ShiBai;
    // Use this for initialization
    void Start ()
    {
       
        JinRu.SetActive(true);
        Cheng.SetActive(false);
        Goumai.SetActive(false);
        ShiBai.SetActive(false);
    }
    public void OnClickShangCheng()
    {
        Cheng.SetActive(true);
        JinRu.SetActive(false);
        Goumai.SetActive(true);
    }
    public void OnClickFanHui()
    {
        print(111);
        JinRu.SetActive(true);
        Goumai.SetActive(false);
        Cheng.SetActive(false);
    }
    public void OnClickShiBai()
    {
        StartCoroutine(GouMaiShiBai());
    }
   
    IEnumerator GouMaiShiBai()
    {
        ShiBai.SetActive(true);
        Cheng.SetActive(false);
        Goumai.SetActive(false);
        yield return new WaitForSeconds(2f);
        ShiBai.SetActive(false);
        Cheng.SetActive(true);
        Goumai.SetActive(true);
    }
    // Update is called once per frame
    void Update ()
    {
	
	}
}
