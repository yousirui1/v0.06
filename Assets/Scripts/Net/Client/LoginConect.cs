
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJson;
using ProtoBuf;
using System.IO;
using System;
using Pomelo.DotNetClient;
using System.Threading;
using UnityEngine.UI;

/**************************************
*FileName: LoginConectr.cs
*User: ysr 
*Data: 2017/12/19
*Describe: Login连接gata和connector服务器和数据处理
**************************************/

public class LoginConect : MonoBehaviour
{
	/** reference object*/
	// for login


	private bool bLoginToRoom = false;


	private PomeloClient pClient;

	private AreaConect area = null;

	// Use this for initialization
	void Start()
	{
		area = GetComponent<AreaConect>();	
		if(area == null)
		{
			area = gameObject.AddComponent<AreaConect>();
		}
	}

	// Update is called once per frame
	void Update()
	{
		/*if (bLoginToRoom)
		{
			Application.LoadLevel("Game");
		}*/
	}

	private bool isHost = false;



	public void onLogin()
	{
		if (null == pClient)
		{
			
			pClient = new PomeloClient();
			pClient.initClient(Config.host, Config.port, () =>
				{

					pClient.connect(null, (data) =>
						{
							Debug.Log("onLogin"+data);
							JsonObject userMsg = new JsonObject();
							userMsg["uid"] = ConectData.Instance.Uid;
							pClient.request("gate.gateHandler.queryEntry", userMsg, onEntryRequest);
						});
				});
		}
	}

	//gata服务器返回的数据
	void onEntryRequest(JsonObject result)
	{
		Debug.Log ("Entry:"+result);
		System.Object code = null;
		if (result.TryGetValue("code", out code))
		{
			if (Convert.ToInt32(code) == 500)
			{
				return;
			}
			else
			{
				pClient.disconnect();
				string host = (string)result["host"];
				int port = Convert.ToInt32(result["port"]);
				pClient.initClient(host, port, () =>
					{
						JsonObject j_msg = new JsonObject();
						j_msg["uid"] = ConectData.Instance.Uid;

						pClient.connect(j_msg, data =>
						{
							Entry();
						});
					});
			}
		}
	}

	//获取connector服务器数据
	void Entry()
	{
		
		JsonObject userMsg = new JsonObject ();
		userMsg.Add ("uid", ConectData.Instance.Uid);
		if (pClient != null) {
			pClient.request ("connector.entryHandler.entry", userMsg, (data) => {
					
				Debug.Log ("Entry" + data);
				onEnter (data);
				area.onEnterRoom();
			});
		} 
	}

	//存储登录数据
	void onEnter(JsonObject userData)
	{
		Debug.Log ("onEnter");
		//ConectData.Instance.UserName = UserName;
		//ConectData.Instance.Channel = Password;
		//存储了在线用户
		//PlayerData.Instance.LoginUserData = userData;

		ConectData.Instance.pClient = pClient;


	}
}
