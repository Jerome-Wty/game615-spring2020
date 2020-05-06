using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat : ReactiveObj
{
    public GameObject leftBorder;
    public GameObject rightBorder;
    public float movSpeed = 50.0f;
    private Vector2 movDir = Vector2.left;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            MovePlane();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == leftBorder)
        {
            movDir = Vector2.right;
        }
        else if (collision.gameObject == rightBorder)
        {
            Debug.Log("GoLeft");
            movDir = Vector2.left;
        }
    }

    public override void ReactStart()
    {
        base.ReactStart();
        isMoving = true;
    }

    private void MovePlane()
    {
        transform.Translate(movDir * movSpeed * Time.fixedDeltaTime);
    }
}
