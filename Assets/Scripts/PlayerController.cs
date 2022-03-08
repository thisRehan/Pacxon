using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject gridBoxes;
    [SerializeField] float xRange;
    [SerializeField] float yRange;
    [SerializeField] GameObject player;
    private Vector3 StartPosition;
    private int life;
    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        BoundMovement();
        Die();
        //Alive();
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Move(Vector3.up);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Move(Vector3.down);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Move(Vector3.left);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Move(Vector3.right);
    }
    void BoundMovement()
    {
        if (transform.position.x < -xRange)
            transform.position = new Vector2(-xRange, transform.position.y);
        if (transform.position.x > xRange)
            transform.position = new Vector2(xRange, transform.position.y);
        if (transform.position.y < -yRange)
            transform.position = new Vector2(transform.position.x, -yRange);
        if (transform.position.y > yRange)
            transform.position = new Vector2(transform.position.x , yRange);

    }
    void Move(Vector3 direction)
    {
        transform.position += direction ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grid"))
        {
            gridBoxes.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            life--;
        }
    }
    //void Alive()
    //{
    //    if (life > 0)
    //        player.gameObject.SetActive(true);

    //}
    void Die()
    {
        if(life < 1)
        {
            Destroy(gameObject);
        }
    }
}