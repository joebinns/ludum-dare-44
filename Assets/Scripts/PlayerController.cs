using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject touching;

    public SpriteMask playerSpriteMask;

    public Animation anim;

    void Start()
    {
        playerSpriteMask = transform.Find("SMask_Player").GetComponentInChildren<SpriteMask>();
    }


    void Update()
    {
        playerSpriteMask.sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInChildren<SpriteMask>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponentInChildren<SpriteMask>().enabled = false;
    }
}
