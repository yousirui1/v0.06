using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using tpgm;
using tpgm.UI;

public class UIEventMgr : MonoBehaviour {
    #region 初始化
    private static UIEventMgr m_instance;

    //获取资源加载实例
    public static UIEventMgr Instance()
    {
        if (m_instance == null)
        {
            m_instance = new GameObject("UIEventMgr").AddComponent<UIEventMgr>();
        }
        return m_instance;
    }



    #endregion

    #region 按钮事件
    public void OnClickEvent(GameObject btnObj)
    {
        Debug.Log("" + btnObj.name);

        switch ((int)UIButtonID.Parse(typeof(UIButtonID), "" + btnObj.name))
        {
            case (int)UIButtonID.btn_login:
                OnLogin(1);
                break;
            case (int)UIButtonID.btn_maclogin:
                OnLogin(2);
                break;
            case (int)UIButtonID.btn_sign:
                OnLogin(4);
                break;
            case (int)UIButtonID.btn_mode1:
                OnRoom(1);
                break;
            case (int)UIButtonID.btn_mode2:
                OnRoom(2);
                break;
            case (int)UIButtonID.btn_mode3:
                OnRoom(3);
                break;
            case (int)UIButtonID.btn_friends:
                OnFriends();
                break;
            case (int)UIButtonID.btn_set:
                OnSet();
                break;
            case (int)UIButtonID.btn_copperbox:
                OnCopperBox();
                break;
            case (int)UIButtonID.btn_goldbox:
                OnGoldBox();
                break;
            case (int)UIButtonID.btn_roomback:
                UIPage.ClosePage();
                break;
            case (int)UIButtonID.btn_friendback:
                UIPage.ClosePage();
                break;
           
        }
    }
    
    void Update()
    {
      
       
    }

    //type 1 账号登录，2 mac登录 3登录过快速登录 4注册
    private void OnLogin(int type)
    {

        LoginSendBuf sendbuf = new LoginSendBuf();

        switch (type)
        {
            case 1:
                {
                    //重连
                    sendbuf.isRetry = 0;
                    sendbuf.checkID = "1";
                    sendbuf.type = 1;
                    //获取数据
                    sendbuf.account = GameObject.Find("input_user").GetComponent<InputField>().text;
                    sendbuf.password = GameObject.Find("input_passwd").GetComponent<InputField>().text;

                    //保存数据
                    PlayerPrefs.SetString("account", sendbuf.account);
                    PlayerPrefs.SetString("password", Md5Util.GetMd5FromStr(sendbuf.password));
                }

                break;
            case 2:
                {
                    sendbuf.isRetry = 0;
                    sendbuf.checkID = "1";
                    sendbuf.type = 2;
                    sendbuf.mac = InfoUtil.Instance().getMac();
                }
                break;
            case 3:
                {
                    if (PlayerPrefs.HasKey("account"))
                    {
                        sendbuf.isRetry = 0;
                        sendbuf.checkID = "1";
                        sendbuf.type = 1;
                        sendbuf.account = PlayerPrefs.GetString("account");
                        sendbuf.password = PlayerPrefs.GetString("password");

                    }
                    else
                    {
                        UIPage.ShowPage<PublicUINotice>("没有数据重新登录");
                    }
                }
                break;
            case 4:
                {
                    UIPage.ShowPage<RegisterUIPage>();
                }
                break;

        }

        LoginRecvBuf recvbuf = new LoginRecvBuf();

        NetHttp.HttpSend<LoginSendBuf, LoginRecvBuf>("http://121.40.149.87:3000/login", sendbuf, recvbuf);


        switch(recvbuf.code)
        {
           /* case (int)Code.Normal:
                UIPage.ShowPage<MainUIPage>();
                PlayerPrefs.SetString("token", recvbuf.token);
                break;
            case (int)Code.ArgErr:
               
                UIPage.ShowPage<PublicUINotice>(ErrStr.CodeStr[(Code)recvbuf.code]);
                
                Debug.LogError("login" + ErrStr.CodeStr[(Code)recvbuf.code]);
                break;
                */
        }
       
       
    }



   

    private void OnRoom(int type)
    {
        /*Debug.Log("OnRoom");
        InfoSendBuf sendbuf = new InfoSendBuf();
        InfoBuf recvbuf = new InfoBuf();
        sendbuf.isRetry = 0;
        sendbuf.checkID = "1";
        sendbuf.user = 1;
        sendbuf.box = 1;
      
        NetHttp.HttpSend<InfoSendBuf, InfoBuf>("http://121.40.149.87:3000/getdata", sendbuf, recvbuf);
       
        UIPage.ShowPage<RoomUIMainPage>();
        Debug.Log("head"+recvbuf.code);
        Debug.Log("head" + recvbuf.utcMs);
        Debug.Log("head" + recvbuf.boxData);*/

    }

    private void OnFriends()
    {
        UIPage.ShowPage<ChatUIPage>();
    }

    private void OnSet()
    {
        UIPage.ShowPage<PublicUISetPage>();
    }

    private void OnCopperBox()
    {
        UIPage.ShowPage<PublicUIAwadPage>();
    }

    private void OnGoldBox()
    {
        UIPage.ShowPage<PublicUIAwadPage>();
    }
    #endregion  

   
}
