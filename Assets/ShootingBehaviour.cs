using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{

    private float timeBetweenSpawns = 0.5f;
    public float timeRemaining;
    public Vector3 startPos;

    public GameObject player;

    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeBetweenSpawns;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(player, transform.position, transform.rotation);
            started = true;

        }
        if (started)
        {
            GetComponent<SpriteRenderer>().enabled = false;

            if (timeRemaining > 0) timeRemaining -= Time.deltaTime;
            else
            {
                Instantiate(player, transform.position, transform.rotation);
                timeRemaining = timeBetweenSpawns;
            }
        }
    }

}
