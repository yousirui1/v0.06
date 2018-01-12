using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using tpgm.UI;


public class RoomUIChatPage : UIPage
{

    public RoomUIChatPage() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        //布局预制体
        uiPath = "Prefab/UI/RoomUI/RoomUIChatPage";

    }

    public override void Awake(GameObject go)
    {
        /*this.gameObject.transform.Find("btn_back").GetComponent<Button>().onClick.AddListener(() =>
        {
            UIPage.ClosePage();
        });

        this.gameObject.transform.Find("btn_back").GetComponent<Text>().text = "";

        this.gameObject.transform.Find("btn_notice").GetComponent<Button>().onClick.AddListener(() =>
        {
            ShowPage<RoomUIMainPage>();
        });*/
    }
}
