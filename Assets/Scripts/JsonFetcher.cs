using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JsonFetcher : MonoBehaviour
{
    public string json_URL;
    private int speed;
    private int max_destroy;
    private int min_destroy;
    private double spwan_time;

    private PlatformSpawner ps;
    private DestroyPlatform dp;
    private PlayerController player;
    void Start()
    {
        //Time.timeScale = 0;
        ps = GameObject.FindObjectOfType<PlatformSpawner>();
        dp = GameObject.FindObjectOfType<DestroyPlatform>();
        player = GameObject.FindObjectOfType<PlayerController>();
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
        JsonData j_data = JsonUtility.FromJson<JsonData>(text);
       
        max_destroy = j_data.pulpit_data.max_pulpit_destroy_time;
        min_destroy = j_data.pulpit_data.min_pulpit_destroy_time;
        spwan_time = j_data.pulpit_data.pulpit_spawn_time;
        speed = j_data.player_data.speed;
        Debug.Log("Spawn time is"+ spwan_time);
        Debug.Log("md" + min_destroy);
        Debug.Log("mad"+ max_destroy);

        player.speed = speed;
        dp.min_destroy = min_destroy;
        dp.max_destroy = max_destroy;
        ps.spawnTime = (float)spwan_time;

        //Time.timeScale = 1;
    }

    public int getSpeed()
    {
        return speed;
    }

    public float getSpawn()
    {
        return (float)spwan_time;
    }

    public int minTime()
    {
        return min_destroy;
    }

    public int maxTime()
    {
        return max_destroy;
    }

}
