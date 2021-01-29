using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform circle;
    public Transform circleBox;

    public Camera cam;

    private bool touched = false;
    private Vector2 pointA;
    private Vector2 pointB;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, cam.transform.position.z));

            circle.transform.position = pointA;
            circleBox.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            circleBox.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            touched = true;
            pointB = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, cam.transform.position.z));

            Debug.Log(pointB);
        }
        else
        {
            touched = false;
        }
    }

    private void FixedUpdate()
    {
        if (touched)
        {
            Vector2 offset = pointB - pointA;
            direction = Vector2.ClampMagnitude(offset, 1.0f);
            circle.transform.position = new Vector3(pointA.x + direction.x, pointA.y + direction.y);
        }
        else
        {
            direction = Vector2.zero;
            circle.GetComponent<SpriteRenderer>().enabled = false;
            circleBox.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}
