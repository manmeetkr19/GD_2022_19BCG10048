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

        WWW www = new WWW(json_URL);
        yield return www;
        if(www.error == null)
        {
            Debug.Log(www.text);
            processData(www.text);
        }
       
    }

    private void processData(string text)
    {
        //JsonData data = FindObjectsOfType<JsonData>();
        JsonData j_data = JsonUtility.FromJson<JsonData>(text);
        Debug.Log(j_data.player_data.speed);
        //Debug.Log(j_data.pulpit_data);
        //speed = j_data.player_data.speed;
        //Debug.Log(speed);
    }

}
