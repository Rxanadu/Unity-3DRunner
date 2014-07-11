//---------------------------------------------------------
// danger controller class
// written by jason walters 2014
// http://www.glitchbeam.com
// https://twitter.com/jasonrwalters
//---------------------------------------------------------

using UnityEngine;
using System.Collections;

public class dangerController : MonoBehaviour
{
    public float zMove;             // object's z movement: adjust in Inspector

    private float length;           // length of object

    // Use this for initialization
    void Start()
    {
        // fetch the object's length.  we'll use this to determine
        // if we've past our camera...
        length = renderer.bounds.size.z * 2;
    }

    // Fixed Update is our Physics update, use when moving rigidbodies...
    void FixedUpdate()
    {
        // apply a constant value to z velocity to
        // move towards or away from player
        rigidbody.velocity = new Vector3(0.0f, 0.0f, zMove);

        // if our object's length is past our camera, then...
        if (rigidbody.position.z < -length)
        {
            // delete our object
            Destroy(gameObject);
        }
    }
}
