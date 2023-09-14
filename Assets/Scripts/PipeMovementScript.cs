using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -15;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is over...
        if (!logic.checkIfGameIsOver())
        {
            if (transform.position.x < deadZone)
            {
                Debug.Log("Pipe Deleted");
                Destroy(gameObject);
            }
                transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
            }
        }
    }
