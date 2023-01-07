using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    private Vector3 direction = Vector3.left;
    public float obsSpeed = 5.0f;

    //Destroy if collided to the character
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ninja")
        {
            Destroy(gameObject);
        }
       
    }

    void Update()
    {
        transform.Translate(direction * obsSpeed * Time.deltaTime);

        if(transform.position.x <= -9)
        {
            direction = Vector3.right;
        }
        else if(transform.position.x >= 9)
        {
            direction = Vector3.left;
        }
    }
}
