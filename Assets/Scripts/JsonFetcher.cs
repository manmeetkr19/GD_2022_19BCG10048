using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JsonFetcher : MonoBehaviour
{
    public string json_URL;
    public int speed;
    public int max_destroy;
    public int min_destroy;
    void Start()
    {
        StartCoroutine(fetchData());
    }

    IEnumerator fetchData()
    {
        /* Debug.Log("Loading.....");

         WWW _www = new WWW(json_URL);

         yield return _www;
         if(_www.error == null)
         {
             processData(_www.text);
             //Debug.Log(_www.text);
         }
         else
         {
             Debug.Log("Error in loading json");
         }*/

        UnityWebRequest request = UnityWebRequest.Get(json_URL);
        request.chunkedTransfer = false;
        yield return request.Send();

        if (request.isNetworkError)
        {

        }
        else
        {
            if (request.isDone)
            {
                JsonData jsonData;
                jsonData = JsonUtility.FromJson<JsonData>(request.downloadHandler.text);
                Debug.Log(jsonData.pulpit_data);
            }
        }

       
    }

    private void processData(string text)
    {
        //JsonData data = FindObjectsOfType<JsonData>();
        JsonData j_data = JsonUtility.FromJson<JsonData>(text);
        //Debug.Log(j_data.pulpit_data);
        speed = j_data.player_data.speed;
        Debug.Log(speed);
    }
}
