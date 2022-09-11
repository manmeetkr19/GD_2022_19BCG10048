using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
	private float size;
	public float spawnTime;
	[SerializeField]
	GameObject platform;

	private Vector3 lastPosition;

	private JsonFetcher data;
	// Use this for initialization
	void Start()
	{
		
		size = platform.transform.localScale.x;
		lastPosition = platform.transform.position;
		data = GameObject.FindObjectOfType<JsonFetcher>();

		//spawnTime = data.getSpawn();
		Debug.Log("time:" + spawnTime);
		InvokeRepeating("SpawnPlatform",2,2.5f);
		//InvokeRepeating("SpawanPlatform", 2.5f,2.5f);
	}



	// Spawn a random platform.
	private void SpawnPlatform()
	{
		int random = Random.Range(0, 6);
	
		if (random < 3)
		{
			SpawnX();
		}

		if (random >= 3)
		{
			SpawnZ();
		}

	}
	private void SpawnX()
	{
		GameObject _platform = Instantiate(platform) as GameObject;
		_platform.transform.position = lastPosition + new Vector3(size, 0f, 0f);
		lastPosition = _platform.transform.position;

	}

	private void SpawnZ()
	{
		GameObject _platform = Instantiate(platform) as GameObject;
		_platform.transform.position = lastPosition + new Vector3(0f, 0f, size);
		lastPosition = _platform.transform.position;
	}

}
