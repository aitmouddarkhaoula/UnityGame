using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float MSpeed = 6;
    public float BodySpeed = 10;
    public int Gap = 10;
    public int Force;
    float TouchRightVal;

    public GameObject BodyPrefab;

    private List<GameObject> Body = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();


    void Start() {
        Grow();
        Grow();
        Grow();
        Grow();
        Grow();
        Grow();

    }

   
    void FixedUpdate() {

        transform.position += transform.forward * MSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * Time.deltaTime * Force;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Time.deltaTime * Force;
            }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchRightVal = touch.deltaPosition.x;
            transform.position += transform.right * TouchRightVal * Time.deltaTime;
        }

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in Body) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

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


    private void Grow() {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        Body.Add(body);
    }
}