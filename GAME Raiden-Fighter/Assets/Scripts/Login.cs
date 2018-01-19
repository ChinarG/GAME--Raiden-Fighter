using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.IO;
using LitJson;

using UnityEditor;

public class Login : MonoBehaviour {

    //用户名框
    public UIInput userNameInput;

    //密码框
    public UIInput passWordInput;

    public UILabel  cuowu;

    public GameObject denglu;

    //用户信息列表模型
    public UserInfoListModel userInfoListModel;

    // Use this for initialization
    void Start () {
        userNameInput = GameObject.Find("UserName").GetComponent<UIInput>();
        passWordInput = GameObject.Find("PassWord").GetComponent<UIInput>();
        cuowu = GameObject.Find("CuoWu").GetComponent<UILabel>();
        denglu = GameObject.Find("Login");
    }


    private void CheckAccountDate()
    {

        if (userNameInput.value == "")
        {
            //弹框提示请输入完整信息
            cuowu.text ="账号不能为空";
        }
        else if (passWordInput.value == "")
        {
            cuowu.text = "密码不能为空";
        }
        else
        {
            //触发时机是用户名密码都已经写了
            FindFiles();
        }

    }

    private void FindFiles()
    {
        string Filepath = Application.dataPath + @"/Resources/LoginInfo.txt";

        //判断文件是否存在
        if (File.Exists(Filepath))
        {
            TextAsset textaa = Resources.Load("LoginInfo") as TextAsset;
            userInfoListModel = JsonMapper.ToObject<UserInfoListModel>(textaa.text);

            bool hasUsers = false;
            int index = 0;

            //比较存储的内容中是否存在和当前输入框中一样的用户名
            for (int i = 0; i < userInfoListModel.UserInfoList.Count; i++)
            {
                //判断是否存在相同的账号
                if (userNameInput.value == userInfoListModel.UserInfoList[i].UserName)
                {
                    index = i;
                    hasUsers = true;
                    //跳出循环 for循环停止执行
                    break;

                }

            }

            if (hasUsers)
            {
                //找到了用户和已经存储的内容相似的
                //
                if (passWordInput.value == userInfoListModel.UserInfoList[index].PassWord)
                {
                    cuowu.text = "登陆成功";
                    denglu.SetActive(false);
                    SceneManager.LoadScene("LeiDian");
                }
                else
                {
                    cuowu.text = "密码错误";
                }

            }
            else
            {
                //输入的用户名在已经存储的信息中没有
                cuowu.text = "用户名不存在";
            }

        }
        else
        {
            //没有文件的情况 软件首次打开的时候
            cuowu.text = "用户名不存在";
        }
    }



    // Update is called once per frame
    void Update () {
		
	}

    public void LoginButtonOnClick()
    {
        CheckAccountDate();

    }

    /// <summary>
    /// 点击跳转到regist页面
    /// </summary>
    //public void RegistButtonOnClick()
    //{

    //    //从Resources中加载注册页面
    //    GameObject registObj = Resources.Load<GameObject>("Registe");
    //    GameObject reigstView = Instantiate(registObj);
    //    reigstView.transform.position = transform.position;
    //    denglu.SetActive(false);
    //}



}
