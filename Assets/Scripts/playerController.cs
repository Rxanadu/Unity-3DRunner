//---------------------------------------------------------
// player controller class
// written by jason walters 2014
// http://www.glitchbeam.com
// https://twitter.com/jasonrwalters
//---------------------------------------------------------

using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
    public float xSpeed = 0.0f;         // x speed
    public float tilt = 0.0f;           // tilt speed
    public float xMin, xMax;            // x movement range

    private float xInput = 0.0f;        // x input
    private float xMove = 0.0f;         // x movement (input * speed)

    // Update is called once per frame
    void Update()
    {
        // use our input's horizontal controls (keys a & d || left & right)
        xInput = Input.GetAxis("Horizontal");
        xMove = xInput * xSpeed;
    }

    // FixedUpdate is a physics update and used when working with rigibodys
    void FixedUpdate()
    {
        // apply input's x movement to rigidbody velocity to move player
        rigidbody.velocity = new Vector3(xMove, 0.0f, 0.0f);

        // multiply our x velocity by our public tilt variable
        // we also reverse the value by multiplying against a negative
        // apply this value to our z rotation to create a tilting effect
        float playerTilt = rigidbody.velocity.x * tilt;
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, playerTilt);

        // clamp player position to be inside game bounds
        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, xMin, xMax),
            rigidbody.position.y,
            0.0f
        );
    }

    // when an object enters player trigger collider
    void OnTriggerEnter(Collider collisions)
    {
        // send this message to our console for debugging
        // this tells us what hit our player
        Debug.Log("Player hit by: " + collisions.gameObject.tag);
    }
}