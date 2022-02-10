using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float force;

    private Rigidbody2D rigidPlanet;

    void Awake()
    {
        rigidPlanet = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetKey("w"))
        {
            rigidPlanet.AddForce(-transform.up * force);
        }
        if (Input.GetKey("s"))
        {
            rigidPlanet.AddForce(transform.up * force);
        }
    }
}
