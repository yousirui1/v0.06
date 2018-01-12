using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


/**************************************
*FileName: UIModelMgr
*User: ysr 
*Data: 2018/1/3
*Describe: 对UImodel进行管理
**************************************/


public class UIModelMgr
{
	protected static UIModelMgr m_instance;
	public static bool hasInstance
	{
		get
		{
			return m_instance != null;
		}

	}

	public static UIModelMgr getInstance()
	{
		if(!hasInstance)
		{
			m_instance = new UIModelMgr();	
		}

		return m_instance;

	}
	


	//存储所以model
	private Dictionary<string, UIDataModel> dictionary;

	private UIModelMgr()
	{
		dictionary = new Dictionary<string, UIDataModel>();
	
	}


	//获取model
	public T GetModel<T>() where  T :UIDataModel
	{
		Type type = typeof(T);
		if(dictionary.ContainsKey(type.Name))
		{
			return dictionary[type.Name] as T;
		}
		
		T model = System.Activator.CreateInstance(type) as T;
		dictionary.Add(type.Name, model);

		return model;

	}


	public void Destroy()
	{
		Clear();
		dictionary = null;
	}

	public void Clear()
	{
		foreach(UIDataModel m in dictionary.Values)
		{
            m.Destroy();
		}
		dictionary.Clear();
	}
	

}
