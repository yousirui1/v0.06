using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using tpgm;

public class GameData
{
	private static GameData m_instance;
	public static GameData Instance
	{
		get
		{
			if(m_instance == null)
			{
				m_instance = new GameData();
			}
			return m_instance;
		}

	}


	public UDFriend playerFriend;
	private GameData()
	{
		playerFriend = new UDFriend();
		playerFriend.friends = new List<UDFriend.Friend>();
		for(int i =0 ; i< 10; i++)
		{
			UDFriend.Friend friend = new UDFriend.Friend();
			friend.nickname = "name" + i;
			friend.uid = ""+1;
			friend.gender = 0;
			friend.head = i;
			friend.level = 0;
			friend.status = 0;
			playerFriend.friends.Add(friend);	
		}
	}

}
