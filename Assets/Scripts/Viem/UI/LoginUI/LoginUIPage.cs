using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using tpgm.UI;
using tpgm;

public class LoginUIPage : UIPage
{

    public LoginUIPage() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        //布局预制体
        uiPath = "Prefab/UI/LoginUI/LoginUIPage";

    }

    public override void Awake(GameObject go)
    {
        //Init(UIValue.login_btnID, UIValue.login_inputID, UIValue.login_txID, UIValue.login_imgID);

        LoginSendBuf sendbuf = new LoginSendBuf();

        this.gameObject.transform.Find("btn_register").GetComponent<Button>().onClick.AddListener(() =>
        {
            // 注册
            UIPage.ShowPage<RegisterUIPage>();
        });

        this.gameObject.transform.Find("btn_login").GetComponent<Button>().onClick.AddListener(() =>
        {
            //登录
            //重连
            sendbuf.isRetry = 0;
            sendbuf.checkID = "1";
            sendbuf.type = 2;
            //获取数据
            sendbuf.account = GameObject.Find("input_user").GetComponent<InputField>().text;
            sendbuf.password = GameObject.Find("input_passwd").GetComponent<InputField>().text;

            //md5加密
            sendbuf.password = Md5Util.GetMd5FromStr(sendbuf.password);

            //保存数据
            PlayerPrefs.SetString("account", sendbuf.account);
            PlayerPrefs.SetString("password", sendbuf.password);
            OnLogin(sendbuf);

        });

        this.gameObject.transform.Find("btn_maclogin").GetComponent<Button>().onClick.AddListener(() =>
        {
            // mac登录
            sendbuf.isRetry = 0;
            sendbuf.checkID = "1";
            sendbuf.type = 1;
            //sendbuf.mac = InfoUtil.Instance().getMac();
			sendbuf.mac ="408D5CED70B2";
            OnLogin(sendbuf);
        });



    }

    private void OnLogin(LoginSendBuf sendbuf)
    {
        LoginRecvBuf recvbuf = new LoginRecvBuf();
        NetHttp.HttpSend<LoginSendBuf, LoginRecvBuf>("http://121.40.149.87:3000/login", sendbuf, recvbuf);
		if (NetHttp.HttpResult(recvbuf.code)) {
			ConectData.Instance.Token = recvbuf.token;
			ConectData.Instance.Uid = recvbuf.uid;

			UIPage.ShowPage<MainUIPage>();
			//保存token后面的连接都通过token
		}
      
        
    }
}
