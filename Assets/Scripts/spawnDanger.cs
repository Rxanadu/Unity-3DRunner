//---------------------------------------------------------
// spawn danger class
// written by jason walters 2014
// http://www.glitchbeam.com
// https://twitter.com/jasonrwalters
//---------------------------------------------------------

using UnityEngine;
using System.Collections;

public class spawnDanger : MonoBehaviour
{
    public GameObject spawnPrefab;         // prefab we are spawning
    public float spawnSeconds;             // spawn every # seconds
    public float xMin, xMax;               // x position range
    public float yMin, yMax;               // y position range
    public float zMin, zMax;               // z position range

    private float timeElapsed = 0.0f;      // time elapsed
    private float prevTime = 0.0f;         // previous time

    // Update is called once per frame
    void Update()
    {
		// our spawn function
        Spawn(spawnSeconds);
    }

    // this function randomizes the spawn point position
    void RandomPosition(float _xMin, float _xMax, float _yMin, float _yMax, float _zMin, float _zMax)
    {
        // grab a random value in our range for x, y, z
        float xMove = Random.Range(_xMin, _xMax);
        float yMove = Random.Range(_yMin, _yMax);
        float zMove = Random.Range(_zMin, _zMax);

        // update the position of our spawner using our random values
        transform.position = new Vector3(xMove, yMove, zMove);
    }

    // this function handles the object spawning, is time controlled
    void Spawn(float _spawnSeconds)
    {
        // create elapsed time by adding delta time
        timeElapsed += Time.deltaTime;

        // if elapsed time minus previous time is greater than spawn seconds, do something...
        if (timeElapsed - prevTime > _spawnSeconds)
        {
			// randomly move our spawner on the x
			RandomPosition(xMin, xMax, yMin, yMax, zMin, zMax);

            // spawn the prefab we referenced in this object's inspector
            // set the prefab's position & rotation to match this spawner
            Instantiate(spawnPrefab, transform.position, transform.rotation);

            // reset our timer by syncing elapsed time with previous time
            prevTime = timeElapsed;
        }
    }
}
