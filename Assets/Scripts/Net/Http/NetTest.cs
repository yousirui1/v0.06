using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJson;
using System.Threading;
using UnityEngine.SceneManagement;

public class NetTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        JsonObject jsMsg = new JsonObject();
        jsMsg.Add("isRetry", 1);
        jsMsg.Add("CheckId", "1");
        jsMsg.Add("type", 1);
        HttpSend("http://121.40.149.87:3000/login", jsMsg);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private Coroutine routine1;

    public void HttpSend(string url, JsonObject json)
    {
        
        WWWForm form = new WWWForm();
        form.AddField("JsonObject", json.ToString());
        routine1 = StartCoroutine(SendPost(url, form));
       
    }

    IEnumerator SendPost(string _url, WWWForm _wFrom)
    {
        WWW postData = new WWW(_url, _wFrom);
        yield return postData;
        if (postData.error != null)
        {
            Debug.Log(postData.error);
        }
        else
        {
            D d = new D();
            JsonUtility.FromJsonOverwrite(postData.text, d);
            Debug.Log("" + d.code);
        }


    }

    public class D
    {



        public int code;
        public string token;
        public string userId;
        public string utcMs;
    }

    IEnumerator SendGet(string _url)
    {
        WWW getData = new WWW(_url);
        yield return getData;

        if (getData.error != null)
        {
            Debug.Log(getData.error);
        }
        else
        {
            Debug.Log(getData.ToString());
        }

    }


}
