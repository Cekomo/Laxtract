using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public float rotSpeed;
    public float force;

    private string key;

    private Rigidbody2D rb2D;

    // [SerializeField]
    private float maxPos = 7.5f;

    GameObject pulseLeftDown, pulseLeftLeft, pulseLeftUp, pulseRightDown, pulseRightRight, pulseRightUp, mainPulse;
    GameObject[] pulses;

    //private float xPos = Mathf.Clamp(transform.position.x, -30, 30);

    // Start is called before the first frame update
    void Awake()
    {
        
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        //transform.position(xPos, transform.position.y, transform.position.z);
    }

    // Determine clamp values in the map for X-axis (-30, 30)

    void Start()
    {
        pulseLeftDown = GameObject.Find("Player/pulseLeftDown");
        pulseLeftLeft = GameObject.Find("Player/pulseLeftLeft");
        pulseLeftUp = GameObject.Find("Player/pulseLeftUp");
        pulseRightDown = GameObject.Find("Player/pulseRightDown");
        pulseRightRight = GameObject.Find("Player/pulseRightRight");
        pulseRightUp = GameObject.Find("Player/pulseRightUp");
        mainPulse = GameObject.Find("Player/mainPulse");
    }

    // Update is called once per frame
    void Update()
    {

        pulses = GameObject.FindGameObjectsWithTag("Pulse");
        for (int i = 0; i < pulses.Length; i++)
        {
            pulses[i].SetActive(false);
        }

        //float xInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //float yInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        float r1Input = rotSpeed * Time.deltaTime;

        // apply "Space.World" if you do not want movement to get affected from rotation
        // "Camera.main.transform" does the similart thing
        // transform.Translate(xInput, yInput, 0);

        // below function adjusts border and its feature
        Move();
        

        if (Input.GetKey("w"))
        {
            rb2D.AddForce(transform.up * force);
            pulseLeftDown.SetActive(true);
            pulseRightDown.SetActive(true);
            mainPulse.SetActive(true);
        }
        if (Input.GetKey("s"))
        {
            rb2D.AddForce(-transform.up * force);
            pulseRightUp.SetActive(true);
            pulseLeftUp.SetActive(true);
        }
        if (Input.GetKey("a"))
        {
            rb2D.AddForce(-transform.right * force);
            pulseRightRight.SetActive(true);
        }
        if (Input.GetKey("d"))
        {
            rb2D.AddForce(transform.right * force);
            pulseLeftLeft.SetActive(true);
        }


        if (Input.GetKey("q"))
        {
            rb2D.AddTorque(rotSpeed * Mathf.Deg2Rad);
            pulseLeftUp.SetActive(true);
            pulseRightDown.SetActive(true);
        }
        if (Input.GetKey("e"))
        {                  
            rb2D.AddTorque(-rotSpeed * Mathf.Deg2Rad);
            pulseLeftDown.SetActive(true);
            pulseRightUp.SetActive(true);
        }

        // I would like module to stop when having too small velocities
        if (rb2D.velocity.magnitude < 0.07)
        {
            if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d"))
            {
                rb2D.velocity = new Vector3(0f, 0f, 0f);
            }
        }

        //print(rb2D.velocity.magnitude);
        //print(rb2D.velocity);
        
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        //transform.position += Vector3.right * inputX * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        // this part has problem such as when border is accessed, y speed is zero as x-speed
        // make zero speed for x-axis only
        // the player sometimes hide behind the background why?
        if (rb2D.position.x == 7.5)
        {
            float speedY = rb2D.velocity.y;
            rb2D.velocity = new Vector2(-0.8f, speedY);

            //rb2D.velocity = Vector2.zero;
            //rb2D.velocity = new Vector3(-0.8f, 0f, 0f);

        }
        else if (rb2D.position.x == -7.5)
        {
            float speedY = rb2D.velocity.y;
            rb2D.velocity = new Vector2(0.8f, speedY);
          
        }
    }
}
