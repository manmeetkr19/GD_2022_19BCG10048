using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
	private float size;

	[SerializeField]
	GameObject platform;

	private Vector3 lastPosition;


	// Use this for initialization
	void Start()
	{
		size = platform.transform.localScale.x;
		lastPosition = platform.transform.position;

		/*// Create the first initial playforms.
		for (int x = 0; x < 15; x++)
		{
			SpawnZ();
		}*/

		// Call the SpawnPlatform every 2 seconds.
		InvokeRepeating("SpawnPlatform", 2f,2);
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
