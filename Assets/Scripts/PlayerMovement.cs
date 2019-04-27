using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _body;

    private Vector2 _inputs = Vector2.zero;
    private Vector2 playerMove = Vector2.zero;

    private float speed = 4f;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()//GET INPUTS & APPLY 'ONE-TIME' PHYSICS
    {
        _inputs = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
    }

    void FixedUpdate()//APPLY CONTINUOUS PHYSICS
    {
        playerMove = (_inputs * speed * Time.fixedDeltaTime);

        _body.MovePosition(_body.position + playerMove);
    }
}
