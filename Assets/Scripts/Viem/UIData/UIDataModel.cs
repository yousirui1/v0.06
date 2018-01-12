using UnityEngine;
using System;
using System.Collections;

/**************************************
*FileName: UIDataModel.cs
*User: ysr 
*Data: 2018/1/3
*Describe: ui基础数据模型
**************************************/

public class UIDataModel
{
	#region 属性事件
	public event EventHandler<ValueUpdateEventArgs> ValueUpdateEvent;

	
	//属性事件触发
	protected void DispatchValueUpdateEvent(string key, object oldValue, object newValue)
	{
		EventHandler<ValueUpdateEventArgs> handler = ValueUpdateEvent;
		if(handler != null)
		{
			handler(this, new ValueUpdateEventArgs(key, oldValue, newValue));
		}
	}

	//属性事件触发
	protected void DispatchValueUpdateEvent(ValueUpdateEventArgs args)
	{
		EventHandler<ValueUpdateEventArgs> handler = ValueUpdateEvent;
		if(handler != null)
		{
			handler(this, args);
		}
	}

	#endregion
	
	#region 模型事件
	//模型事件定义
	public event EventHandler<ModelEventArgs> ModelEvent;

	//模型事件触发
	protected void DispatchModelEvent(string type, params object[] args)
	{

	}
	
	//模型事件触发
	protected void DispatchModelEvent(ModelEventArgs args)
	{

	}

	#endregion

	//清理数据
	virtual public void Destroy()
	{
		ModelEvent = null;
		ValueUpdateEvent = null;
	}


}

//模型事件
public class ModelEventArgs : EventArgs
{
	public string type { get ; set; }
	public object [] args;

	public ModelEventArgs(String type, params object[] args)
	{
		this.type = type;
		this.args = args;
	}

	public ModelEventArgs()
	{

	}
}


//数据更新事件
public class ValueUpdateEventArgs : EventArgs
{
	public string key { get; set;  }

	public object oldValue { get; set;}

	public object newValue { get; set;}


	public ValueUpdateEventArgs(String key, object oldValue, object newValue)
	{
		this.key = key;
		this.oldValue = oldValue;
		this.newValue = newValue;

	}

}



