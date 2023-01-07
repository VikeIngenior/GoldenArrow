using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class character : MonoBehaviour
{
    public Animator animator;

    public float speed = 10f;
    public float jumpForce;
    private Rigidbody rb;
    bool isOnGround = false;
    
    float life = 100f;
    float cur_life = 100f;
    public Image health_bar;

    public GameObject lost_panel;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            cur_life -= 33.4f;
            health_bar.fillAmount = cur_life / life;
            if(cur_life<=0)
            {
                lost_panel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    // Start is called before the first frame update

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        isOnGround = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            Transform transform = gameObject.GetComponent<Transform>();
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("run");
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Transform transform = gameObject.GetComponent<Transform>();
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("const");
        }
        
        //Clamping characters rightmost and leftmost positions
        float clampedPos = Mathf.Clamp(transform.position.x, -6.5f, 6.5f);
        transform.position = new Vector3(clampedPos, transform.position.y, transform.position.z); 
    }
}
