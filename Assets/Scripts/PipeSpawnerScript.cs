using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 1;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        //if the game is over...
        if (!logic.checkIfGameIsOver())
        { 
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnPipe();
                timer = 0;
            }
        } 
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset / 10;
        float highestPoint = transform.position.y + heightOffset / 10;
        Instantiate(pipe, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
