using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public int min_destroy=4;
    public int max_destroy=5;

    private JsonFetcher data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindObjectOfType<JsonFetcher>();

        //Debug.Log("min an max" + data.minTime() + " " + data.maxTime());
        int time = Random.Range(min_destroy,max_destroy);
        Debug.Log("Destroy in"+time);
        Destroy(gameObject,3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = GameObject.FindObjectOfType<PlayerController>();
            player.ScoreAdd();
            var uiManager = GameObject.FindObjectOfType<UIManager>();
            uiManager.ScoreUpdate(player.ScoreFetcher());
        }
    }
}
