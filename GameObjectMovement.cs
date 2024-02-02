using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectMovement : MonoBehaviour
{
    float speed = 7.5f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);


        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
 
        }
    }
}