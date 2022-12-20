using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float mSpeed = 10;
    private float bodySpeed = 10;
    private int gap = 4;
    public int force;
    float touchRightVal;
    [SerializeField] Obstacles _obstacle;

    public GameObject BodyPrefab;

    public List<GameObject> _body = new List<GameObject>();
    private List<Vector3> _positionsHistory = new List<Vector3>();


    void Start() {
        Grow();
        Grow();
        Grow();
        Grow();
        Grow();
        print(_body.Count);

    }

   
    void FixedUpdate() {

        transform.position += transform.forward * mSpeed * Time.fixedDeltaTime;
        if (_body.Count == 0)
        {
            GameManager.instance.ShowLoseUI();
            Time.timeScale = 0;
            Application.Quit();

        }
        if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * Time.fixedDeltaTime * force;
            }
        if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Time.fixedDeltaTime * force;
            }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchRightVal = touch.deltaPosition.x;
            transform.position += transform.right * touchRightVal * Time.deltaTime;
        }

        // Store position history
        _positionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in _body) {
            Vector3 point = _positionsHistory[Mathf.Clamp(index * gap, 0, _positionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * bodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }

        if(transform.position.y < -1)
        {
            Time.timeScale = 0;
            Application.Quit();
        }
    }
    public void RemoveBall()
	{
        Destroy(_body[0].gameObject);
        _body.RemoveAt(0);
    }
#pragma warning disable IDE0051 // Supprimer les membres privés non utilisés
    /*private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.tag == "Player")
         {
             Destroy(collision.gameObject);
             Grow();

         }


     }*/
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();
        int n = obstacle.number;
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Grow();
        }
    }/*
        if (other.gameObject.tag == "Enemy" )
        {
            if (_body.Count >= n) {
                for (int i = 0; i < n; i++)
                {
                    Destroy(_body[0].gameObject);
                    _body.RemoveAt(0);
                    obstacle.SetNumber(obstacle.number - 1);
                }
            }
            else
			{
                for (int i = 0; i < _body.Count+1; i++)
                {
                    Destroy(_body[0].gameObject);
                    _body.RemoveAt(0);
                    obstacle.SetNumber(obstacle.number - 1);
                }
                _body.Clear();
            }
            
            if(obstacle.number == 0)
			{
                Destroy(obstacle.gameObject);
			}
            
        }

    }*/

    private void Grow() {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        _body.Add(body);
    }
}