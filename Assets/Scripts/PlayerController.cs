using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject touching;

    void Start()
    {
        
    }


    void Update()
    {
        
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
