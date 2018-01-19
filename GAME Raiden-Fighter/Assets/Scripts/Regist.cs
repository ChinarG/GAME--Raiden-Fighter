using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

using UnityEditor;


public class UserInfoModel
{


    public string UserName;
    public string PassWord;
    //public bool isRember;
   
}



public class UserInfoListModel
{
    
    public List<UserInfoModel> UserInfoList = new List<UserInfoModel>();

}



public class Regist : MonoBehaviour {

    public UIInput userNamelabe; // 用户名
    public UIInput passWordLabe; // 密码
    public UIInput ConfirmLabe;  // 确认密码
    public UILabel mistake;
    
    public UserInfoListModel userInfoListModel;
    // Use this for initialization
    void Start () {

        GameObject obj;
        //声明的时候 创造了一个obj指针 
        //这时候指针是空的 没有指向内存地址

        //赋值的时候才有内容 
        //实现方法是 将空的指针指向了这个内存地址
        obj = GameObject.Find("RegistAccount");

        //GetComponentInChildren 从物体中获取它子物体的组件
        userNamelabe = obj.GetComponentInChildren<UIInput>();

        //确认密码
        //obj抛弃了之前的指针地址
        //换了一个新的指针地址
        obj = GameObject.Find("ConfirmPassWord");
        ConfirmLabe = obj.GetComponentInChildren<UIInput>();


        //密码
        obj = GameObject.Find("RegistPassWord");
        passWordLabe = obj.GetComponentInChildren<UIInput>();

        obj = GameObject.Find("mistake");
        mistake = obj.GetComponentInChildren<UILabel>();
    }
    private void CheckAccountDate()
    {

        if (userNamelabe.value == "" || passWordLabe.value == "" || ConfirmLabe.value == "")
        {
            //弹框提示请输入完整信息
           mistake.text="信息不完整";
        }
        else if (passWordLabe.value != ConfirmLabe.value)
        {
            //弹框提示密码不一致
            mistake.text = "密码不一致";
        }
        else
        {
            //触发时机是用户名密码都已经写了
            FindFiles();
        }

    }
    private UserInfoModel CheckInfo()
    {

        //少了一个判断
        UserInfoModel userinfo = new UserInfoModel();
        userinfo.UserName = userNamelabe.value;
        userinfo.PassWord = passWordLabe.value;

        return userinfo;
    }

    private void FindFiles()
    {

        string Filepath = Application.dataPath + @"/Resources/LoginInfo.txt";

        //判断文件是否存在
        if (File.Exists(Filepath))
        { //文件存在
          //取出来内容

            TextAsset textaa = Resources.Load("LoginInfo") as TextAsset;
            userInfoListModel = JsonMapper.ToObject<UserInfoListModel>(textaa.text);


            bool hasUsers = false;

            //比较存储的内容中是否存在和当前输入框中一样的用户名
            for (int i = 0; i < userInfoListModel.UserInfoList.Count; i++)
            {
                //判断是否存在相同的账号
                if (userNamelabe.value == userInfoListModel.UserInfoList[i].UserName)
                {

                    hasUsers = true;
                    //跳出循环 for循环停止执行
                    break;

                }

            }
            if (hasUsers)
            {

                //找到了和已经存储的内容相似的
                //弹出来一个框提示
                mistake.text = "用户已经存在";

            }
            else
            {

                //存储
                // SaveUserInfo(Filepath);
                //用户名不存在
                userInfoListModel.UserInfoList.Add(CheckInfo());
                mistake.text = "注册成功";
            }


        }
        else
        { //不存在文件
          //创建一个
          //用户名密码存在
            userInfoListModel = new UserInfoListModel();
            userInfoListModel.UserInfoList.Add(CheckInfo());
            //存储
           // SaveUserInfo(Filepath);
            //弹框提示注册成功
            
        }

        //存储
        SaveUserInfo(Filepath);

    }
    private void SaveUserInfo(string Filepath)
    {


        //创建文本
        FileInfo file = new FileInfo(Filepath);
        StreamWriter stream = file.CreateText();
        string jsonStr = JsonMapper.ToJson(userInfoListModel);
        stream.WriteLine(jsonStr);
        stream.Close();
        stream.Dispose();

        AssetDatabase.Refresh();//自动的刷新文件

        

    }

    public void RegistButtonClick()
    {
        //点了按钮 判断注册信息
        CheckAccountDate();

    }
    


    // Update is called once per frame
    void Update () {
		
	}
}
