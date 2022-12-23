using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //public GameObject ballPrefab;
    public PlayerController snake;

    bool _destroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_destroy)
            return;

        Obstacle obstacle = other.GetComponent<Obstacle>();
        if (other.gameObject.tag == "Enemy")
		{
            _destroy = true;
            snake.RemoveBall(this);
            //GameManager.instance.DecrementProgress(1 / 10f);
            obstacle.SetNumber(obstacle.number - 1);
            if (obstacle.number == 0)
            {
                Destroy(obstacle.gameObject);
            }

        }


    }
    public void Grow(PlayerController snake)
    {
        this.snake = snake;
        // Instantiate body instance and
        // add it to the list
        snake._body.Add(gameObject);
    }
}
