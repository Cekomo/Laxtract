using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideEffect : MonoBehaviour
{

    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
       
    }

    void OnTriggerEnter2D(Collider2D collider)
    {       
        player = collider.transform.gameObject;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            
    }
}
