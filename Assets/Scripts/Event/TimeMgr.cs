using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMgr : MonoBehaviour {
    #region 初始化
    private static TimeMgr m_instance;
    //获取资源加载实例
    public static TimeMgr Instance()
    {
        if (m_instance == null)
        {
            m_instance = new GameObject("TimeMgr").AddComponent<TimeMgr>();
        }
        return m_instance;
    }
    #endregion


    // Use this for initialization
    void Start () {
        
    }

	private float count = 0;

	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		if (count >= 1) {
			ConectData.Instance.NewTime += 1000;
			count = 0;
		}
    }

    //根据服务器时间矫正时间
    public void ReTime()
    {

    }

    public void InitTime()
    {
        ConectData.Instance.NewTime = 0;
    }
}
