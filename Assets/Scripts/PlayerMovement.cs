using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _body;

    private Vector2 _inputs = Vector2.zero;

    private int _latestInput = 0;
    private int _lastInput = 0;

    private Vector2 playerMove = Vector2.zero;
    private float _attack = 0f;

    private float speed = 4f;

    private bool _isAxisInUse = false;
    private bool _isXAxisInUse = false;
    private bool _isYAxisInUse = false;

    private PlayerController playerController;
    private GameObject _touching;
    private List<GameObject> _LightTiles;

    public Vector2Int gridDimensions = Vector2Int.zero;

    public int index;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        _LightTiles = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LightTiles;
    }

    void Update()//GET INPUTS & APPLY 'ONE-TIME' PHYSICS
    {
        //INPUTS
        _inputs = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;

        _attack = Input.GetAxisRaw("Attack");

        //GET BUTTON DOWN
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (_isXAxisInUse == false)
            {
                // Call your event function here.
                _latestInput = Mathf.RoundToInt(_inputs.x);

                _isXAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            _latestInput = Mathf.RoundToInt(_inputs.y * 2);

            _isXAxisInUse = false;
        }

        //GET BUTTON DOWN
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (_isYAxisInUse == false)
            {
                // Call your event function here.
                _latestInput = Mathf.RoundToInt(_inputs.y) * 2;

                _isYAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            _latestInput = Mathf.RoundToInt(_inputs.x);

            _isYAxisInUse = false;
        }


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
                    }
                }
            }
        }
    }

    public IEnumerator attackPause(int _lastInput, float delay, bool what)
    {
        yield return new WaitForSeconds(delay);
        attackLights(_lastInput, false);
    }

    private void Attack()
    {
        //GET VALUES
        _touching = playerController.touching;
        index = _touching.transform.GetSiblingIndex();

        int _lastInput = _latestInput;
        attackLights(_lastInput, true);

        StartCoroutine(attackPause(_lastInput, 0.5f, false));
    }
}
