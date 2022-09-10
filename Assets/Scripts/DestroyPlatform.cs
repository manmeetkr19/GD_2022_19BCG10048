using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Destroy()", 5f);
        Destroy(gameObject, 3f);
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
