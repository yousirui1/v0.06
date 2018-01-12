using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using tpgm.UI;


public class RoomUITopBarPage : UIPage
{
    
    public RoomUITopBarPage() : base (UIType.Normal, UIMode.HideOther, UICollider.None)
	{
        //布局预制体
        uiPath = "Prefab/UI/RoomUI/RoomUITopBarPage";

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
        this.gameObject.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() =>
        {
            // Room
            UIPage.ClosePage();
        });
    }
}
