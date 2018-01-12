using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using tpgm.UI;


public class PublicUISetPage : UIPage
{

    public PublicUISetPage() : base(UIType.PopUp, UIMode.DoNothing, UICollider.Normal)
    {
        //布局预制体
        uiPath = "Prefab/UI/PublicUI/PublicUISetPage";

    }

    public override void Awake(GameObject go)
    {
        this.gameObject.transform.Find("Button (6)").GetComponent<Button>().onClick.AddListener(() =>
        {
            // 隐藏
            Hide();
        });
    }
}
