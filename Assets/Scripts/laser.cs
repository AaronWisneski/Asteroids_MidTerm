using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    private Rigidbody2D reg;
    public float speed = 500f;
    public float maxLifetime = 10f;
    private void Awake()
    {
        reg = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        reg.AddForce(direction * this.speed );

        Destroy(this.gameObject, this.maxLifetime );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
