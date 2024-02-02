using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    float speed = 2.5f;
    float minY = -2.0f;
    float maxY = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Start the automatic movement coroutine
        StartCoroutine(AutomaticMovement());
    }

    IEnumerator AutomaticMovement()
    {
        while (true)
        {
            while (transform.position.y < maxY)
            {
                transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
                yield return null;
            }

            while (transform.position.y > minY)
            {
                transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
                yield return null;
            }
        }
    }
}