using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using tpgm.UI;

public class PublicUINotice : UIPage
{
    public PublicUINotice() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "Prefab/UI/PublicUI/PublicUINotice";
    }

    public override void Awake(GameObject go)
    {
        string st = (string)this.data;
        this.gameObject.transform.Find("content/Text").GetComponent<Text>().text = st;
        this.gameObject.transform.Find("content/btn_confim").GetComponent<Button>().onClick.AddListener(() =>
        {
            Hide();
        });
        
    }

    public override void Refresh()
    {
        
    }
}
