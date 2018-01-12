using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJson;
using System.Net.NetworkInformation;
using tpgm;

public class InfoUtil : MonoBehaviour
{
   

    #region 初始化
    private static InfoUtil m_instance;

    //获取资源加载实例
    public static InfoUtil Instance()
    {
        if (m_instance == null)
        {
            m_instance = new GameObject("InfoUtil").AddComponent<InfoUtil>();
        }
        return m_instance;
    }

    #endregion



    //GPS服务
    private LocationService locationServer;
    private LocationServiceStatus locationServerStatus;
    private LocationInfo locationInfo;

   

    // Use this for initialization
    void Start () {

       
    }

    // Update is called once per frame
    void Update () {
       
    }

    public string getMac()
    {
        string Mac = "";
        bool isFind = false;
        NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface ni in nis)
        {
			if (!isFind)
            {
                Debug.Log("Name" + ni.Name);
                Debug.Log("Des" + ni.Description);
                Debug.Log("Type" + ni.NetworkInterfaceType.ToString());
				Debug.Log("Mac" + ni.GetPhysicalAddress().ToString());
                Mac = ni.GetPhysicalAddress().ToString();
				if(Mac != "")
                isFind = true;
            }
			else 
            {
				break;
            }
        }
        return Mac;
    }

    public void getGPS(GPSVal gps)
    {
        //GPS Sever
        locationServer = Input.location;
        gps.isCould = locationServer.isEnabledByUser; //用户是否可以设置定位服务        
        locationServerStatus = locationServer.status; //返回设备服务状态  
        //参数1 服务所需的精度，以米为单位，参数2 最小更新距离  
        locationServer.Start(1, 1);//开始位置更新服务，最后的位置坐标  
                                   //locationServer.Stop();//停止位置服务更新，节省电池寿命 
                                   //调用该方法之前确保调用了 Input.location.Start()

        //GPS Info
        locationInfo = locationServer.lastData; //设备最后检测的位置  
        gps.altitude = locationInfo.altitude;//设备高度  
        gps.horizontalAccuracy = locationInfo.horizontalAccuracy; //水平精确度  
        gps.verticalAccuracy = locationInfo.verticalAccuracy; //垂直精确度  
        gps.latitude = locationInfo.latitude; //设备纬度  
        gps.longitude = locationInfo.longitude;//设备纬度  
        gps.timestamp = locationInfo.timestamp;//时间戳(自1970年以来以秒为单位)位置时最后一次更新。
    }

}
