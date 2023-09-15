using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float movementSpeed = 1.5f;

    public MoveDirection direction;
    private Vector3 origionalPosition;
    private void Start() { 
        origionalPosition = transform.position;
        Debug.Log(origionalPosition);
    }

    public enum MoveDirection
    {
        Left,
        Right
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.position = origionalPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == MoveDirection.Left)
        {
            transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0);
        }
        if (direction == MoveDirection.Right)
        {
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0);
        }


    }
}
