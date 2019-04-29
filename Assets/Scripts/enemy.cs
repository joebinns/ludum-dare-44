using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    private GameObject Player;
    private float speed = 4f;

    private Vector2 move = Vector2.zero;

    private Rigidbody2D _body;

    public GameObject playerClone;

    private bool dead;

    public bool lastEnemy;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        _body = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        move = (transform.position - Player.transform.position).normalized * speed * Time.deltaTime;
        _body.MovePosition(_body.position - move);
    }

    private void Die()
    {
        //get this game objects position, destroy this game object, instantiate player object at this position.
        Vector3 _position = transform.position;

        Destroy(this.gameObject);

        Instantiate(playerClone, _position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            collision.GetComponentInChildren<SpriteMask>().enabled = true;

            if (collision.GetComponentInChildren<SMask>().dangerous == true)
            {
                if (dead != true)
                {
                    Die();
                }
 
                dead = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            collision.GetComponentInChildren<SpriteMask>().enabled = true;

            if (collision.GetComponentInChildren<SMask>().dangerous == true)
            {
                if (dead != true)
                {
                    Die();
                }

                dead = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            collision.GetComponentInChildren<SpriteMask>().enabled = false;
        }
    }
}
