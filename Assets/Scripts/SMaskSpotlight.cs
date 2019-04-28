using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMaskSpotlight : MonoBehaviour
{
    [Range(0f, 2f)]
    public float addSize;

    float timer = 0;

    float flickTime;

    private void calculateBeatFreq()
    {
        float bpm = 120f;
        flickTime = bpm / (60f * 4f);
    }

    private void Start()
    {
        calculateBeatFreq();
    }

    void Update()
    {
        timer += (Time.deltaTime);

        addSize = Mathf.Sin(timer * Mathf.PI * flickTime) * 2;

        //addSize = Mathf.Sin(timer * Mathf.PI / 2) * Mathf.Log10(timer * Mathf.PI / 2);

        transform.localScale = new Vector3(addSize, addSize, 1);
    }
}
