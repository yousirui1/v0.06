using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using tpgm.UI;
using DG.Tweening;
using tpgm;


public class RoomUIMainPage : UIPage
{
   
	private GameObject friendItem = null;
	private GameObject friendList = null;

	private List<UIFriendItem> friendItems = new List<UIFriendItem>();

	//当前item
	private UIFriendItem currentItem = null;	

	private TabControl tabControl = null;

	private List<TabIndex> tablist = new  List<TabIndex> ();
		

	public RoomUIMainPage() : base (UIType.Normal, UIMode.HideOther, UICollider.None )
	{
		//布局预制体
		uiPath = "Prefab/UI/RoomUI/RoomUIMainPage";
       
	}

	public override void Awake(GameObject go)
	{
        //Init(UIValue.room_btnID, UIValue.room_inputID, UIValue.room_txID, UIValue.room_imgID);



		tabControl = this.transform.Find ("tabcontrol").GetComponent<TabControl> () as TabControl;

		tablist.Add (new TabIndex(0,"好友"));
		tablist.Add (new TabIndex(1,"最近"));
		tablist.Add (new TabIndex(2,"附近"));

		for (int i = 0; i < tablist.Count; i++) {
			tabControl.CreateTab (tablist[i].id, tablist[i].tabname);
		}


		friendList = this.transform.Find("tabcontrol/Panels/Panel(Clone)").gameObject;

		friendItem = this.transform.Find("tabcontrol/Panels/Panel(Clone)/Viewport/Content/item").gameObject;
		friendItem.SetActive(false);

		this.transform.Find("user1").GetComponent<Button>().onClick.AddListener(() =>
			{
				Refresh();
			});
			
    }

	
	//更新
	public override void Refresh()
	{
		friendList.transform.localScale = Vector3.zero;	
		friendList.transform.DOScale(new Vector3(1, 1, 1), 0.5f);

		//Get Friend Data
		//查看前一个页面有没有传入参data没有则初始化GameData	
		//UDFriend.friends friendData = this.data != null ? this.data as UDFriend : GameData.Instance.playerFriend;


		if (ConectData.Instance.friedns == null) {
			//ConectData.Instance.friedns = GameData.Instance.playerFriend.friends;
		} else {
			for (int i = 0; i < ConectData.Instance.friedns.Count; i++) {
				CreateFriendItem (ConectData.Instance.friedns [i]);
			}
		}

	}

	//隐藏
	public override void Hide()
	{
		for(int i = 0; i< friendItems.Count ;i++)
		{
			GameObject.Destroy(friendItems[i].gameObject);
		}
		friendItems.Clear();

		this.gameObject.SetActive(false);
	}


	#region this logic

	private void CreateFriendItem(UDFriend.Friend friend)
	{
		GameObject go = GameObject.Instantiate(friendItem) as GameObject;
		go.transform.SetParent(friendItem.transform.parent);
		go.transform.localScale = Vector3.one;
		go.SetActive(true);
		
		UIFriendItem item = go.AddComponent<UIFriendItem>();
		item.Refresh(friend);
		friendItems.Add(item);	

		//add click btn listener
		go.AddComponent<Button>().onClick.AddListener(OnClickFriendItem);

	}
	
	//邀请好友
	private void OnClickFriendItem()
	{
		//获取好友信息
		UIFriendItem item = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<UIFriendItem>();
		//发送给服务端	
		//Client.Send
	}



	#endregion


}
