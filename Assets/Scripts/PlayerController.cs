using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public int speed = 8;
    public GameObject gameOver;

    private int score = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Time.timeScale = 1;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -10)
        {
            Stop();
        }

        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
        }

        transform.position = pos;
    }

    void Stop()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public int ScoreFetcher()
    {
        return score;
    }

    public void ScoreAdd()
    {
        score += 1;
    }
}
