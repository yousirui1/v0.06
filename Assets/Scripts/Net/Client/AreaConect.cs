﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pomelo.DotNetClient;
using SimpleJson;
using System.Threading;
using UnityEngine.SceneManagement;
using tpgm;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class AreaConect : MonoBehaviour {
   
	private static AreaConect instance = null;

	private TaskExecutor mTaskExecutor = null;

	public static AreaConect Instance
	{
		get { return instance; }
	}

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		//注册主线程
		mTaskExecutor = GetComponent<TaskExecutor>();
		if(mTaskExecutor == null)
			mTaskExecutor = gameObject.AddComponent<TaskExecutor>();

		//注册网络事件监听
		InitNetEvent();

		
	}	

	//发送加入房间请求
	public void onEnterRoom()
	{

		if (ConectData.Instance.pClient != null) {
			ConectData.Instance.pClient.request ("area.gloryHandler.enterRoom", (data) => {
				Debug.Log ("onEnterRoom" + data);

				UDFriend.FriendBuf buf = null;
				if(null != data)
				{
					
					buf = JsonConvert.DeserializeObject<UDFriend.FriendBuf>(data.ToString());
					ConectData.Instance.friedns = new List<UDFriend.Friend>(buf.friendArr);
					ConectData.Instance.roomNum = buf.roomNum;

					//ConectData.Instance.Channel = buf.frienaArr =UDfriends;
					//eventObj.onove(buf);
				}
			});
		} else {
			Debug.LogError ("pClient null");
		}


	}


	//网络监听事件
	private void InitNetEvent()
	{
		Debug.Log("InitNetEvent");

		PomeloClient pClient = ConectData.Instance.pClient;

		if (pClient != null)
		{
			pClient.on("add", (data) => {
				Debug.Log("InitNetEvent onAdd");
				//onUserAdd(data);
			});

			pClient.on("onLeave", (data) => {
				Debug.Log("InitNetEvent onLeave" + data);
				//onUserLeave(data);
			});

			pClient.on("message", (data) =>
			{
				Debug.Log("InitNetEvent message" +data);
				//onChatAdd(data);
			});
		}
	}

	
}
