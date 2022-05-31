using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    public Vector2 flygHastighet;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bird jump when you press the spacebar 
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = flygHastighet;
        }
    }
}
