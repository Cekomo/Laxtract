using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material material;
    Vector2 offset;
    
    private Rigidbody2D rbwp;
        
    public float yVelocity;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    
    void Start()
    {
        
    }

    
    void Update() { 
    
        float yInput = Input.GetAxis("Vertical") * yVelocity; // do I need  "* Time.deltaTime" ? 
                
        offset = new Vector2(0f, yInput);
        material.mainTextureOffset += offset * Time.deltaTime;

        Vector2 speedW = offset;
        if (Input.GetKeyDown("w"))
        {
            //print(offset.y);
            
            while (speedW.y > 0.0000000000000007)
            {
                material.mainTextureOffset += speedW * Time.deltaTime;
                speedW = new Vector2(0f, speedW.y / 5);
                //print(speedW.y);
            }
        }
        if (Input.GetKeyDown("s"))
        {
            //print(offset.y);
            while (speedW.y > 0.0000000000000007)
            {
                material.mainTextureOffset += speedW * Time.deltaTime;
                speedW = new Vector2(0f, speedW.y / 5);
                //print(speedW.y);
            }
        }

        
    }
}
