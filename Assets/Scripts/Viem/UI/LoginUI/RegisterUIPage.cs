using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using tpgm.UI;
using tpgm;

public class RegisterUIPage : UIPage
{

    public RegisterUIPage() : base(UIType.PopUp, UIMode.DoNothing, UICollider.WithBg)
    {
        //布局预制体
        uiPath = "Prefab/UI/LoginUI/RegisterUIPage";

    }

    public override void Awake(GameObject go)
    {
        this.gameObject.transform.Find("content/btn_register").GetComponent<Button>().onClick.AddListener(() =>
        {
            LoginSendBuf sendbuf = new LoginSendBuf();
            LoginRecvBuf recvbuf = new LoginRecvBuf();

            //重连
            sendbuf.isRetry = 0;
            sendbuf.checkID = "1";
            sendbuf.type = 1;
            //获取数据
            sendbuf.account = GameObject.Find("content/input_user").GetComponent<InputField>().text;
            sendbuf.password = GameObject.Find("content/input_passwd1").GetComponent<InputField>().text;


            Debug.Log("" + sendbuf.account);
            string password2 = GameObject.Find("content/input_passwd2").GetComponent<InputField>().text;

            if (sendbuf.password != password2)
            {
                Debug.LogError("2次输入的密码不一致");
                Debug.Log(sendbuf.password);
                Debug.Log(password2);
            }
            else
            {
                //md5加密
                sendbuf.password = Md5Util.GetMd5FromStr(sendbuf.password);


                NetHttp.HttpSend<LoginSendBuf, LoginRecvBuf>("http://121.40.149.87:3000/register", sendbuf, recvbuf);
                if(NetHttp.HttpResult(recvbuf.code))
                {
                    //保存数据
                    PlayerPrefs.SetString("account", sendbuf.account);
                    PlayerPrefs.SetString("password", sendbuf.password);

                    UIPage.ShowPage<MainUIPage>();
                }
  
              
                
            }

          
        });

    }
}
