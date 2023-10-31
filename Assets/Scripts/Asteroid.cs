using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f;
    public float maxLife = 30.0f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D reg;
    public BoxCollider2D col;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        reg = GetComponent<Rigidbody2D>();
       // col = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
        reg.mass = this.size;
        col.size =  1.25f * this.size * Vector3.one;
    }

    public void SetTrajectory(Vector2 direction) 
    {
        reg.AddForce(direction * this.speed );
        Destroy(this.gameObject, this.maxLife);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            if(this.size * 0.5 >= this.minSize)
            {
                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
        }
            
            
    }
    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);

    }
}

