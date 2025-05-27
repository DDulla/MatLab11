using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 5f;
    private float destroyXPosition = -15f; 

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}
