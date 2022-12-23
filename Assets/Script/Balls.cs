using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public GameObject ballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject body = Instantiate(ballPrefab);
            body.transform.position = new Vector3(Random.Range(-7, 8), 1.5f, Random.Range(40f, 350f));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
