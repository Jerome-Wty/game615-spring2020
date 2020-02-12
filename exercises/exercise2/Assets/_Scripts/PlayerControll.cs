using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public GameObject piggy;
    public float power = 50f;
    private Rigidbody2D piggyBody;
    float MAX_ANGLE = 90f;
    float MIN_ANGLE = 0f;

    // Start is called before the first frame update
    void Start()
    {
        piggyBody = piggy.GetComponent<Rigidbody2D>();
        piggyBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // mouse point on screen is read from Input and by moving to 0 on z axis from the camera position
        Vector3 mousePointOnScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(mousePointOnScreen);
        Vector3 direction = mouseInWorld - transform.position;

        // to find an angle between two vectors, you need to calculate the Dot product between the NORMALIZED vetors.
        // and retrieve the angle from the dot product, by calculating arccosine of it

        float cosAlpha = Vector3.Dot(Vector3.right, direction.normalized);



        float angle = Mathf.Acos(Vector3.Dot(Vector3.right, direction.normalized)) * Mathf.Rad2Deg;

        if (angle <= MAX_ANGLE && angle > MIN_ANGLE && direction.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (Input.GetButtonDown("Fire1") && piggy.transform.parent)
        {
            piggy.transform.parent = null;
            piggyBody.gravityScale = 1;
            piggyBody.AddForce(direction * power);
        }

    }
}
