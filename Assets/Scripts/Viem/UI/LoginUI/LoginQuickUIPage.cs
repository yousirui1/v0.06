using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using tpgm.UI;


public class LoginQuickUIPage : UIPage
{

    public LoginQuickUIPage() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        //布局预制体
        uiPath = "Prefab/UI/LoginUI/LoginQuickUIPage";

    }

    public override void Awake(GameObject go)
    {
        //Init(UIValue.login_btnID, UIValue.login_inputID, UIValue.login_txID, UIValue.login_imgID);
        this.gameObject.transform.Find("loginbtn").GetComponent<Button>().onClick.AddListener(() =>
        {

        });

    }
}
