using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using tpgm.UI;

public class SceneMgr
{
	
	#region 初始化
	protected static SceneMgr m_instance;
	public static bool hasInstance
	{
		get
		{
			return m_instance != null;
		}
	}


	public static SceneMgr getInstance()
	{
		if(!hasInstance)
		{
			m_instance = new SceneMgr();
		}
		return m_instance;
	}

	#endregion 	
	

	//存储当前已经实例化的场景
	public Dictionary<SceneType, SceneBase> scenes;

	//当前场景
	public SceneBase current;

	//记录切换数据
	private List<SwitchRecorder> switchRecoders;
	
	//主场景
	private const SceneType mainSceneType = SceneType.SceneTest;



	private SceneMgr()
	{
		scenes = new Dictionary<SceneType, SceneBase>();
		switchRecoders = new List<SwitchRecorder>();	
	}

	//场景切换
	public void SwitchingScene(SceneType sceneType, params object[] sceneArgs)
	{
		if(current != null)
		{
			if(sceneType == current.type)
			{
				Debug.LogError("切换当前场景:" + sceneType.ToString());
				return;
			}
		}

		//进入主场景,把场景记录清空
		if(sceneType == mainSceneType)
		{
			switchRecoders.Clear();
		}
		
		//切换记录
		switchRecoders.Add(new SwitchRecorder(sceneType));
		
		HideCurrentScene();
		ShowScene(sceneType);
		
		/*if(OnSwitchingSceneHandler != null)
		{
			OnSwitchingSceneHandler(sceneType);
		}*/

	}


	//切换至上一个场景
	public void SwitchingToPrevScene()
	{
		
	}

	//打开指定的场景
	private void ShowScene(SceneType sceneType)
	{
        //判断是否载入过
        /*if(scenes.ContainsKey(sceneType))
		{
			current = scenes[sceneType];
			current.OnShowing();
		
		}
		else
		{


		}*/
        //判断是否登录过
       // if(PlayerPrefs.HasKey("account"))
        {
           
            //UIPage.ShowPage<LoginQuickUIPage>();
        }
        //else
        {
            UIPage.ShowPage<LoginUIPage>();
        }
       
    }

	//关闭当前场景
	private void HideCurrentScene()
	{

	}


	internal struct SwitchRecorder
	{
		internal SceneType sceneType;
		//internal object[] sceneArgs;

		internal SwitchRecorder(SceneType sceneType)
		{
			this.sceneType = sceneType;
		}
	}
}
