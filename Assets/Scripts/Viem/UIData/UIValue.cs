using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace tpgm.UI
{
    public enum UIPrefabID
    {
        ChatUIMainPage = 0,

        CreateRoteUI,

        LoadUIPage,

        LoginUIPage,

        PublicUIAwadPage,
        PublicUISetPage,
        PublicUITabControl,

        RoomUIMainPage,
        RoomUIMatchPage,
    }

    public enum UIButtonID
    {
        btn_sign = 0,   //注册  login 0
        btn_login,       //登录
        btn_maclogin,   //mac登录   

            
       // btn_quicklogin,   //快速登录   3


        btn_bigback,     //大礼包   main 4
        btn_firstpay,    //首冲
        btn_info,        //背包系统
        btn_task,        //任务
        btn_achievement, //成就
        btn_draw,        //抽奖
        btn_friends,    //好友
        btn_store,   //商城
        btn_hid,       //隐藏设置  10
        btn_set,       //设置
        btn_email,      //邮件
        btn_check,      //签到
        btn_activity,   //签到
        btn_rank,       //排行榜  
        btn_copperbox,     //铜箱子
        btn_goldbox,        //金箱子
        btn_mode1,      //游戏模式1
        btn_mode2,      //游戏模式2 
        btn_mode3,      //快速开始


        btn_roomback,   //房间返回  room 23
        btn_checkmode,   //切换游戏模式  
        btn_user1,
        btn_user2,
        btn_user3,
        btn_quickMessage, //快捷语
        btn_send,       //发送
        btn_switchListen, //语音开关
        btn_switchSend,   //语音开关
        btn_start,      //开始游戏  20
        
        btn_friendback,  //好友界面返回 friend 33
        btn_find,
        


        btn_sure,   // 25
        btn_cancel,     //取消
        
        
        btn_addUser,
    }

    
    //(UIButtonID) System.Enum.Parse(typeof(UIButtonID), 1.ToString());
    
    public enum UITextID
    {
        tx_user = 0, //login 0 
        tx_passwd,

        tx_name,      //main 2
        tx_leveup,

        tx_roomTitle,  //room 4
        tx_user1name,
        tx_user2name,
        tx_user3name,
        tx_Message,   //

    }

    public enum UIInputFieldID
    {
        input_user = 0,  //login 0 
        input_passwd,
                        //main 0
        input_roomsendMessage, //room 2

        input_chatsendMessage, //chat 3
    }


    public enum UIIamgeID
    {

        img_login_bg = 0,   //login 0 
        pic_loading,

        main_bg,            //main 2
        img_head,

        img_room_bg,           //room 4
        img_room_user1,
        img_room_user2,
        img_room_user3,
        img_room_chatbg,
    }

    public class UIValue
    {
        //用字典存储所以得页面数据
        private static Dictionary<string, string> m_allUIpath;
        public static Dictionary<string, string> allUIpath
        { get { return m_allUIpath; } }


        public const int login_btnID = 0;
        public const int login_txID = 0;
        public const int login_inputID = 0;
        public const int login_imgID = 0;


       // public const int login_imgID = 0;


        public const int main_btnID = 3;
        public const int main_txID = 2;
        public const int main_inputID = 0;
        public const int main_imgID = 2;


        public const int room_btnID = 22;
        public const int room_txID = 4;
        public const int room_inputID = 2;
        public const int room_imgID = 4;

        public const int friends_btnID = 32;
        public const int friends_txID = 5;
        public const int friends_inputID = 3;
        public const int friends_imgID = 4;



        /*if (m_allPages.ContainsKey(pageName))
          {
              page = m_allPages[pageName];
          }
          else
          {
              m_allPages.Add(pageName, pageInstance);
              page = pageInstance;
          }
  }*/
        void ontest()
        {
            string st = UIIamgeID.GetName(typeof(UIIamgeID), 3);
        }
         
        public static string[] UIPathPrefab = { "Prefab/UI/ChatUI/ChatUIMainPage",  

                                         "Prefab/UI/CreateRoteUI/",

                                         "Prefab/UI/LoadUI/LoadUIPage",
                                         
                                         "Prefab/UI/LoginUI/LoginUIPage",

                                         "Prefab/UI/MainUI/LoadUIPage",

                                         "Prefab/UI/PublicUI/PublicUIAwadPage",
                                         "Prefab/UI/PublicUI/PublicUISetPage",
                                         "Prefab/UI/PublicUI/Tab/PublicUITabControl",

                                         "Prefab/UI/RoomUI/RoomUIMainPage",
                                         "Prefab/UI/RoomUI/RoomUIMatchPage",
                                         "Prefab/UI/RoomUI/RoomUIRankPage",
                                         "Prefab/UI/RoomUI/RoomUIGameEndPage",
                                         
                                        };


        public  static string[] UIPathTexture = { "Public/Texture/pic_login",
                                            "Public/Texture/pic_loading",
                                            "Public/Texture/pic_bg",      //背景资源
                                         

                                          "Public/Atlases/Icon/General_icon",  //头像 0-113

                                          "Public/Texture/pic_bg",
                                         "Public/Atlases/Icon/General_icon",  //头像 0-113
                                         "Public/Atlases/Icon/General_icon",  //头像 0-113
                                         "Public/Atlases/Icon/General_icon",  //头像 0-113
                                          "Public/Texture/pic_login",
                                        
                                          //"Public/Atlases/ui_atlas_img_local_normal",  //按钮图标 0-113

                                        };

       


    }
}

