using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trcube : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigid;
    bool onGround;
    private void OnCollisionStay(Collision other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Plane")
        {
            //Debug.Log("evet");
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        onGround = false;
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //GameObject.Find("zemin").SetActive(false);
    }

    private void Update()
    {
        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigid.AddForce(Vector2.up * 350);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(3 * Time.deltaTime, 0, 0, Space.World);
            //GetComponent<Rigidbody>().velocity=Vector3.right * 150 * Time.deltaTime;
            //GetComponent<Rigidbody>().AddForce(transform.right * 550 * Time.deltaTime);
            Debug.Log(onGround);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-3 * Time.deltaTime, 0, 0, Space.World);
            //GetComponent<Rigidbody>().velocity=Vector3.right * 150 * Time.deltaTime;
            Debug.Log(onGround);
        }

        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(0, 0, -60 * Time.deltaTime, Space.World);
        }


    }
}
