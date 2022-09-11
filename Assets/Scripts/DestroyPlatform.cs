using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public int min_destroy;
    public int max_destroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Detected");
            var player = GameObject.FindObjectOfType<PlayerController>();
            player.ScoreAdd();
            var uiManager = GameObject.FindObjectOfType<UIManager>();
            uiManager.ScoreUpdate(player.ScoreFetcher());
        }
    }
}
