using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using tpgm.UI;


public class ChatUIPage : UIPage
{

    public ChatUIPage() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        //布局预制体
        uiPath = "Prefab/UI/ChatUI/ChatUIMainPage";

    }

    public override void Awake(GameObject go)
    {
        Init(UIValue.friends_btnID, UIValue.friends_inputID, UIValue.friends_txID, UIValue.friends_imgID);
        
    }
}
