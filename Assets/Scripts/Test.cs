using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using tpgm;
using tpgm.UI;

public class Test : MonoBehaviour {

	private LoginConect conect = null;
	// Use this for initialization
	void Start () {
        /*LoginSendBuf sendbuf = new LoginSendBuf();
        sendbuf.isRetry = 0;
        sendbuf.checkID = "1";
        sendbuf.type = 1;
        sendbuf.mac = "asd";*/
       

        //LoginRecvBuf recvbuf = new LoginRecvBuf();

        //NetHttp.HttpSend<LoginSendBuf, LoginRecvBuf>("http://121.40.149.87:3000/login", sendbuf , recvbuf);
        //Debug.Log("" + recvbuf.code);
        //Debug.Log("" + recvbuf.code);
        //Debug.Log("" + recvbuf.code);
        //Debug.Log("" + recvbuf.code);

        //Debug.Log(""+Md5Util.GetMd5FromStr("ysr"));
		//TimeMgr.Instance().InitTime();
		//UIPage.ShowPage<UISkillPage>();

		conect = GetComponent<LoginConect>();
		if (conect == null)
			conect = gameObject.AddComponent<LoginConect>();
		
		//conect.onLogin (InfoUtil.Instance().getMac());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
