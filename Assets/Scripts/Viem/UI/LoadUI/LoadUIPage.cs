using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using tpgm.UI;


public class LoadUIPage : UIPage
{
    private long nowTime;
    public LoadUIPage() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        //布局预制体
        uiPath = "Prefab/UI/LoadUI/LoadUIPage";

    }

    public override void Awake(GameObject go)
    {
        UIPage.ShowPage<MainUIPage>();
        /* nowTime = (System.DateTime.Now.Ticks - System.DateTime.Parse("1970-01-01").Ticks) / 10000000;
         while(((System.DateTime.Now.Ticks - System.DateTime.Parse("1970-01-01").Ticks) / 10000000 - nowTime) >3)
         {
             UIPage.ShowPage<MainUIPage>();
             break;
         }*/

    }


}
