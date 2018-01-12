using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMgr : MonoBehaviour {
    #region 初始化
    private static ErrorMgr m_instance;
    //获取资源加载实例
    public static ErrorMgr Instance()
    {
        if (m_instance == null)
        {
            m_instance = new GameObject("ErrorMgr").AddComponent<ErrorMgr>();
        }
        return m_instance;
    }
    #endregion


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    #region 错误
    public enum Code
    {
        None = 0,
        Normal = 200,
        ArgErr = 400,
        PasswdErr = 1000,
        UserIDReErr = 1001,
        DataErr = 1002,
        MacReErr = 1003,
        UserNameReErr = 1004,

    }

    public class ErrStr
    {
        public static Dictionary<Code, string> CodeStr = new Dictionary<Code, string>
        {
            { Code.None , "" },
            { Code.Normal , "正常" },
            { Code.ArgErr , "参数错误" },
            { Code.PasswdErr , "账号或密码错误" },
            { Code.UserIDReErr , "账号已存在" },
            { Code.DataErr , "数据出错" },
            { Code.MacReErr , "该mac地址已绑定账号，请用账号登录" },
            { Code.UserNameReErr , "昵称重复" }
        };
    }
    #endregion

    #region Error logic
    public void Err_Event(int code)
    {
        Debug.LogError("" + ErrStr.CodeStr[(Code)code]);
    }

    #endregion
}
