using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool {
    private static Queue<GameObject> rewardpool; //地图奖励资源队列
    private static GameObject prefab_reward; //地图奖励资源物体
    private static Transform rewardParent; //奖励父物体

    

    public static Queue<GameObject> RewardPool(GameObject obj, int initialCapacity)
    {
        prefab_reward = obj;
        rewardParent = GameObject.Find("Canvas").transform;
        rewardpool = new Queue<GameObject>(initialCapacity);//实例化一个队列 并制定初始大小
       
        for (int i = 0; i < initialCapacity; i++)
        {
            GameObject objClone = GameObject.Instantiate(prefab_reward) as GameObject;
            objClone.transform.SetParent(rewardParent);
            objClone.name = "reward" + i.ToString();
            objClone.SetActive(false);
            rewardpool.Enqueue(objClone);
        }
        return rewardpool;
    }


    public static GameObject GetObjFromPool(Queue<GameObject> pool, Vector3 objPosition)
    {
        GameObject obj = null;

        if (pool.Count > 0)//如果池中存在对象
        {
            obj = pool.Dequeue();
            obj.transform.position = objPosition;
        }
        else
        {
            obj = GameObject.Instantiate(prefab_reward) as GameObject;
            obj.transform.parent = rewardParent;
            pool.Enqueue(obj);
        }
        //设为true即为取出
        obj.SetActive(true);
        return obj;
    }

    //将对象 回收 入池中
    public void Recycle(Queue<GameObject> pool, GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }



}
