using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMask : MonoBehaviour
{
    //[Range(0.05f, 1f)]
    //public float flickTime;
    private float flickTime;

    [Range(0f, 2f)]
    public float addSize;

    float timer = 0;
    private bool bigger = true;

    private void calculateBeatFreq()
    {
        float bpm = 120f;
        flickTime = bpm / (60f * 8f);
    }

    private void Start()
    {
        calculateBeatFreq();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > flickTime)
        {
            if (bigger)
            {
                transform.localScale = new Vector3(transform.localScale.x + addSize, transform.localScale.y + addSize, transform.localScale.z);
            }

            else
            {
                transform.localScale = new Vector3(transform.localScale.x - addSize, transform.localScale.y - addSize, transform.localScale.z);
            }

            timer = 0;
            bigger = !bigger;
        }
    }
}
