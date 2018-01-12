using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using tpgm.UI;
using tpgm;

public class PublicUIAwadPage : UIPage
{

    public PublicUIAwadPage() : base(UIType.PopUp, UIMode.DoNothing, UICollider.WithBg)
    {
        //布局预制体
        uiPath = "Prefab/UI/PublicUI/PublicUIAwadPage";

    }

    public override void Awake(GameObject go)
    {
        ItemAwad awad = (ItemAwad)this.data;

        this.gameObject.transform.Find("content/img_awad0").GetComponent<Image>().sprite = ResourceMgr.Instance().Load<Sprite>("Public/Item/Awad/awad" + awad.id, false);

        this.gameObject.transform.Find("content/tx_awad0").GetComponent<Text>().text = ""+awad.num;

        ConectData.Instance.userInfo.gold += awad.num;
        //child.GetComponent<SpriteRenderer>().sprite =

        this.gameObject.transform.Find("content/btn_confim").GetComponent<Button>().onClick.AddListener(() =>
        {
            // 隐藏
            Hide();
        });


    }
}
