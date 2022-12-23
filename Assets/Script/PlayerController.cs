using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour {
    [SerializeField] float mSpeed = 25;
    [SerializeField] float bodySpeed = 10;
    [SerializeField] int gap = 2;
    [SerializeField] int n = 1;
    public int force;
    public TextMesh count;
    float touchRightVal;
    //[SerializeField] Obstacles _obstacle;
    [SerializeField] Ball _ball;
    public GameObject BodyPrefab;

    public List<GameObject> _body = new List<GameObject>();
    private List<Vector3> _positionsHistory = new List<Vector3>();

    //animation
   

    void Start() {
        Snake();

    }
	

   
    void FixedUpdate() {
        if(!GameManager.instance.play) {
            return;
        }
        float n = 400f - 21f;
        float k = transform.position.z - 21f;
        GameManager.instance.SetProgress(k / n);
        count.text = _body.Count + "";
        transform.position += transform.forward * mSpeed * Time.fixedDeltaTime;
        
        if (transform.position.z == 100.1f)
        {
            print("win");
            GameManager.instance.ShowWinUI();
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
        if (_body.Count == 0)
        {
            GameManager.instance.play = false;
            GameManager.instance.ShowLoseUI();
            Time.timeScale = 0;
            Application.Quit();

        }
        if(transform.position.y < -1)
        {
            GameManager.instance.ShowLoseUI();
            Time.timeScale = 0;
            Application.Quit();
        }
    }
    public void RemoveBall(Ball ball)
	{
        Destroy(ball.gameObject);
        _body.Remove(ball.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.HideGrowUI();
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Ball ball = Instantiate(this._ball);
            ball.transform.position = transform.position - Vector3.forward * _body.Count;
            ball.Grow(this);
            GameManager.instance.ShowGrowUI();
            
        }
        if (other.gameObject.name == "End")
        {
            print("win");
            GameManager.instance.ShowWinUI();
            Time.timeScale = 0;
            Application.Quit();

        }
    }
    public void Snake()
    {
        for (int i = 0; i < n; i++){
            Ball ball = Instantiate(this._ball);
            ball.Grow(this);
        }
        

    }
}