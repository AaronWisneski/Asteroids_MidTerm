using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f;
    public float maxLife = 30.0f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D reg;
    public PlayerMovement player;
    public float distance = 3.0f;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        reg = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        reg.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        reg.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLife);


    }
    public void Move(Transform vampire)
    {
            vampire.transform.position = Vector3.MoveTowards(vampire.transform.position, player.transform.position, distance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stake")
        {

            FindObjectOfType<GameManager>().VampireDestroyed(this);
            Destroy(this.gameObject);
        }
    }
}
