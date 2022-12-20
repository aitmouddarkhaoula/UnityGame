using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacles : MonoBehaviour
{
    public Obstacle ObstaclePrefab;
    public List<Obstacle> obstacles;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            Obstacle body = Instantiate(ObstaclePrefab);
            body.transform.position = new Vector3(Random.Range(-7, 8), 1.43f, Random.Range(60, 304));
            body.SetNumber(Random.Range(2, 5));
            obstacles.Add(body);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
   
}
