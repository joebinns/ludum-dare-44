using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePlayerController : MonoBehaviour
{
    public GameObject touching;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            touching = collision.gameObject;
            collision.GetComponentInChildren<SpriteMask>().enabled = true;
        }

        else if (collision.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            collision.GetComponentInChildren<SpriteMask>().enabled = true;
        }

        //else if (collision.tag == "Enemy")
        //{
        //    Destroy(this.gameObject);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            collision.GetComponentInChildren<SpriteMask>().enabled = false;
        }
    }


}
