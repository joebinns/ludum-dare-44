using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePlayerMovement : MonoBehaviour
{
    public Vector2 _move;

    private Rigidbody2D _body;

    private GameObject player;

    //private PlayerController playerController;
    private PlayerMovement playerMovement;


    //ATTACKING
    public GameObject touching;

    private ClonePlayerController clonePlayerController;
    private GameObject _touching;
    private List<GameObject> _LightTiles;

    public Vector2Int gridDimensions = Vector2Int.zero;

    public int index;

    private int _latestInput = 0;
    private int _lastInput = 0;

    private bool _isAxisInUse = false;

    public SMaskSpotlight _spotlight;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerMovement = player.GetComponent<PlayerMovement>();
        clonePlayerController = GetComponent<ClonePlayerController>();


        _body = GetComponent<Rigidbody2D>();

        _LightTiles = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LightTiles;


        _spotlight = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponentInChildren<SMaskSpotlight>();

        //Vector2 posDiff = player.transform.position - _body.transform.position;
    }

    void Update()
    {
        _move = playerMovement.playerMove;
        _latestInput = playerMovement._latestInput;


        //GET BUTTON DOWN
        if (Input.GetAxisRaw("Attack") != 0)
        {
            if (_isAxisInUse == false)
            {
                // Call your event function here.
                if (Mathf.Abs(_spotlight.addSize) <= 0.5f)
                {
                    Attack();
                }
            }
        }
        if (Input.GetAxisRaw("Attack") == 0)
        {
            _isAxisInUse = false;
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log(_move);
        //_body.transform.position = (_body.position + _move);
        _body.MovePosition(_body.position + _move);
        //_body.MovePosition()
    }

    private void attackLights(int _latestInput, bool what)
    {
        for (int i = 0; i < _LightTiles.Count; i++)
        {
            if (_latestInput == 1)
            {
                if (i > index)
                {
                    if (i % gridDimensions.y == index % gridDimensions.y)
                    {
                        _LightTiles[i].GetComponentInChildren<SpriteMask>().enabled = what;
                        _LightTiles[i].GetComponentInChildren<SMask>().dangerous = what;
                    }
                }
            }

            else if (_latestInput == -1)
            {
                if (i < index)
                {
                    if (i % gridDimensions.y == index % gridDimensions.y)
                    {
                        _LightTiles[i].GetComponentInChildren<SpriteMask>().enabled = what;
                        _LightTiles[i].GetComponentInChildren<SMask>().dangerous = what;
                    }
                }
            }

            else if (_latestInput == 2)
            {
                if (i > index)
                {
                    if ((int)(i / gridDimensions.y) == (int)(index / gridDimensions.y))
                    {
                        _LightTiles[i].GetComponentInChildren<SpriteMask>().enabled = what;
                        _LightTiles[i].GetComponentInChildren<SMask>().dangerous = what;
                    }
                }
            }

            else if (_latestInput == -2)
            {
                if (i < index)
                {
                    if ((int)(i / gridDimensions.y) == (int)(index / gridDimensions.y))
                    {
                        _LightTiles[i].GetComponentInChildren<SpriteMask>().enabled = what;
                        _LightTiles[i].GetComponentInChildren<SMask>().dangerous = what;
                    }
                }
            }
        }
    }

    public IEnumerator attackPause(int _lastInput, float delay, bool what)
    {
        yield return new WaitForSeconds(delay);

        clearLights();
    }

    private void clearLights()
    {
        for (int i = 0; i < _LightTiles.Count; i++)
        {
            if (i != index)
            {
                _LightTiles[i].GetComponentInChildren<SpriteMask>().enabled = false;
                _LightTiles[i].GetComponentInChildren<SMask>().dangerous = false;
            }
        }
    }

    private void Attack()
    {
        //GET VALUES
        _touching = clonePlayerController.touching;

        if(_touching != null)
        {
            index = _touching.transform.GetSiblingIndex();

            _lastInput = _latestInput;
            attackLights(_lastInput, true);

            StartCoroutine(attackPause(_lastInput, 0.2f, false));
        }
    }
}
