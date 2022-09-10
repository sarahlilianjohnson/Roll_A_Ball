using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XAxisEnemyMovement : MonoBehaviour
{
    public float min = 1f;
    public float max = 20f;
    // Use this for initialization
    void Start()
    {

        min = transform.position.x;
        max = transform.position.x + 10;

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

    }
}
