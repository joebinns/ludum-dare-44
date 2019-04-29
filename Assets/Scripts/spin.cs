using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{

    float timer = 0f;

    Quaternion _startRot;

    // Start is called before the first frame update
    void Start()
    {
        _startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        timer += (Time.deltaTime);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Floor(timer) * 90)) * _startRot;
    }
}
