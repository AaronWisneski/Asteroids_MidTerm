using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{//16.42

    //Variables ********************************************
    //is the player trying to move?
    private bool thrust;
    public float thrust_strength = 1.0f;
    private float turn_direction;  
    public float turn_strength = 1.0f;
    private Rigidbody2D reggie;


    public laser laserPrefab;
    public laser stakePrefab;


    //Functions *******************************************

    private void Awake()
    {
        reggie = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        thrust = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow); 

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turn_direction = 1.0f;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turn_direction = -1.0f;
        }
        else
        {
            turn_direction = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            shootstake();
        }
    }
    private void FixedUpdate()
    {
        if(thrust)
        {
            reggie.AddForce(this.transform.up * this.thrust_strength);
        }
        if (turn_direction != 0.0)
        {
            reggie.AddTorque(turn_direction * this.turn_strength);
        }
    }
    private void shoot()
    {
        laser bullet = Instantiate(this.laserPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }
    private void shootstake()
    {
        laser bullet = Instantiate(this.stakePrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Vampire")
        {
            reggie.velocity = Vector3.zero;
            reggie.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();

        }


    }

}
