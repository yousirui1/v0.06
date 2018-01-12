using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using tpgm.UI;

/**************************************
*FileName: Main.cs
*User: ysr 
*Data: 2018/1/2
*Describe: 入口主函数
**************************************/

public class Main : MonoBehaviour
{
	void Start()
	{
        //判断是否登录过
        // if(PlayerPrefs.HasKey("account"))
        {

            //UIPage.ShowPage<LoginQuickUIPage>();
        }
        //else
        {
            UIPage.ShowPage<LoginUIPage>();
        }

        if(!PlayerPrefs.HasKey("hid"))
        {
            PlayerPrefs.SetInt("hid", 0);
        }

		//远程打印
        NetLog.Instance();
		//定时器
        TimeMgr.Instance().InitTime();

		//登录服务器
		//ClientMgr.Instance().SetUrl(Config.host, Config.port);
    }
}
