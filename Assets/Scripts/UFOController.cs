using UnityEngine;
using System.Collections;

public class UFOController : MonoBehaviour
{
    public Rigidbody2D UFORigidbody;
    public int movementSpeed = 500;
    private float hori;
    private float vert;
    private Vector2 touchOrigin = -Vector2.one; //Used to store location of screen touch origin for mobile controls.

    void Update()
    {
        hori = Input.GetAxisRaw("Horizontal"); // x-axis
        vert = Input.GetAxisRaw("Vertical"); // y-axis

        //Check if Input has registered more than zero touches
        if (Input.touchCount > 0)
        {
            //Store the first touch detected.
            Touch myTouch = Input.touches[0];

            //Check if the phase of that touch equals Began
            if (myTouch.phase == TouchPhase.Began)
            {
                //If so, set touchOrigin to the position of that touch
                touchOrigin = myTouch.position;
            }

            //If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                //Set touchEnd to equal the position of this touch
                Vector2 touchEnd = myTouch.position;

                //Calculate the difference between the beginning and end of the touch on the x axis.
                float x = touchEnd.x - touchOrigin.x;

                //Calculate the difference between the beginning and end of the touch on the y axis.
                float y = touchEnd.y - touchOrigin.y;

                //Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
                touchOrigin.x = -1;

                //Check if the difference along the x axis is greater than the difference along the y axis.
                if (Mathf.Abs(x) > Mathf.Abs(y))
                    //If x is greater than zero, set horizontal to 1, otherwise set it to -1
                    hori = x > 0 ? 1 : -1;
                else
                    //If y is greater than zero, set horizontal to 1, otherwise set it to -1
                    vert = y > 0 ? 1 : -1;
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 movement = new Vector2(hori, vert);

        UFORigidbody.AddForce(movement * movementSpeed * Time.deltaTime);
    }
}
