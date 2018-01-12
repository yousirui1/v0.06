using UnityEngine;
using System.Collections;
using tpgm.UI;

/**************************************
*FileName: SceneBase.cs
*User: ysr 
*Data: 2018/1/2
*Describe: 场景基类
**************************************/


public class SceneBase : MonoBehaviour
{
	protected bool m_cache = false;

	//缓存标识
	public bool cache
	{
		get
		{
			return m_cache;
		}
	}


	//场景类型 场景id
	protected SceneType m_type;
	public SceneType type
	{
		get
		{
			return m_type;
		}
	}


	//初始化场景
	public virtual void OnInit()
	{
	    

	}

	public virtual void OnShowing()
	{
        
        //UIPage.ShowPage("", new RoomUITopBarPage());
    }

	//重置数据
	public virtual void OnResetArgs()
	{


	}

	public virtual void OnShowed()
	{

	}
	
	//开始隐藏
	public virtual void OnHiding()
	{

	}	
	
	//隐藏后
	public virtual void OnHided()
	{

	}

}



public enum SceneType
{
	//测试场景
	SceneTest,
	SceneTest2,

	//登录
	SceneLogin,

	//加载
	SceneLoding,
	
	//创建角色
	SceneCreateRote,
	
	//主界面
	SceneMain,
	
	//准备房间
	SceneRoom,

	//商城
	SceneStore,
	
}
