using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {
    private int rewardMax = 500;
    private GameObject reward;
    Queue<GameObject> rewardPool = new Queue<GameObject>();

    // Use this for initialization
    void Start () {
        rewardPool = ObjectPool.RewardPool(reward, rewardMax);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
