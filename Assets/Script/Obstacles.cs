using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacles : MonoBehaviour
{
    public Obstacle ObstaclePrefab;
    public List<Obstacle> obstacles;
    [SerializeField] int max = 6;
    [SerializeField] int min = 1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Obstacle body = Instantiate(ObstaclePrefab);
            body.transform.position = new Vector3(Random.Range(-7, 8), 1.27f, Random.Range(40f, 350f));
            body.SetNumber(Random.Range(min, max));
            obstacles.Add(body);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
   
}
