using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMgr : MonoBehaviour {
	#region 初始化
	private static ClientMgr m_instance;
	//获取资源加载实例
	public static ClientMgr Instance()
	{
		if (m_instance == null)
		{
			m_instance = new GameObject("ClientMgr").AddComponent<ClientMgr>();
		}
		return m_instance;
	}
	#endregion

	private LoginConect login = null;
	private AreaConect area = null;

	// Use this for initialization
	void Awake () {
		login = GetComponent<LoginConect>();	
		if(login == null)
		{
			login = gameObject.AddComponent<LoginConect>();
		}

		area = GetComponent<AreaConect>();	
		if(area == null)
		{
			area = gameObject.AddComponent<AreaConect>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetUrl(string host, int port)
	{
		login.SetUrl (host,port);
	}

	public void CreatRoom()
	{
		area.onEnterRoom ();
	}
}
