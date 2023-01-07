using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptyObject : MonoBehaviour
{
    public Animator animator;

    public float speed = 10f;
    public float jumpForce;
    private Rigidbody rb;
    bool isOnGround = false;
    private float rotationspeed = 180;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate characters direction when pressed to right/left arrows
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isOnGround) //Can jump only once 
            {
                animator.SetTrigger("jump");
                rb.AddForce(Vector2.up * jumpForce);

            }

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetTrigger("run");
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            //transform.rotation = Quaternion.LookRotation(movement);
            transform.Rotate(Vector3.down, rotationspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("run");
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            //transform.rotation = Quaternion.LookRotation(movement);
            transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("const");
        }
    }
}
