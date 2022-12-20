using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Ball ballPrefab;
    [SerializeField] PlayerController _snacke;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
#pragma warning disable IDE0051
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();
        if (other.gameObject.tag == "Enemy")
		{
            _snacke.RemoveBall();
            //Destroy(ballPrefab.gameObject);
            obstacle.SetNumber(obstacle.number - 1);

        }


    }
}
