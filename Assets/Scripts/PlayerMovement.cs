using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _body;

    private Vector2 _inputs = Vector2.zero;
    private Vector2 playerMove = Vector2.zero;
    private float _attack = 0;

    private float speed = 4f;

    private bool _isAxisInUse = false;

    private PlayerController playerController;
    private GameObject _touching;
    private List<GameObject> _LightTiles;

    public Vector2 gridDimensions = Vector2.zero;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        _LightTiles = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LightTiles;
    }

    void Update()//GET INPUTS & APPLY 'ONE-TIME' PHYSICS
    {
        //INPUTS
        _inputs = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;

        _attack = Input.GetAxisRaw("Attack");


        //GET BUTTON DOWN
        if (Input.GetAxisRaw("Attack") != 0)
        {
            if (_isAxisInUse == false)
            {
                // Call your event function here.
                Attack();

                _isAxisInUse = true;
            }
        }

        if (Input.GetAxisRaw("Attack") == 0)
        {
            _isAxisInUse = false;
        }
    }

    void FixedUpdate()//APPLY CONTINUOUS PHYSICS
    {
        playerMove = (_inputs * speed * Time.fixedDeltaTime);

        _body.MovePosition(_body.position + playerMove);
    }

    private void Attack()
    {
        //GET VALUES
        _touching = playerController.touching;

        //Get tiles in latest move direction for attack
        // index of tile standing on
        int index = _touching.transform.GetSiblingIndex();

        for(int i = 0; i < _LightTiles.Count; i++)
        {
            //if (i % 2 == 0)
            //{
            //    _LightTiles[i].GetComponentInChildren<SpriteMask>().enabled = true;
            //}

            //if (index == i )
            //{
            //    _LightTiles[i].GetComponentInChildren<SpriteMask>().enabled = true;
            //}

            //if ((i > index) && (i % gridDimensions.y == 0))
            //{
            //    _LightTiles[i + (int)(i % gridDimensions.y)].GetComponentInChildren<SpriteMask>().enabled = true;
            //}

            if (i >= index)
            {
                if (i % gridDimensions.y == index % gridDimensions.y)
                {
                    _LightTiles[i].GetComponentInChildren<SpriteMask>().enabled = true;
                }


            }
        }
    }
}
