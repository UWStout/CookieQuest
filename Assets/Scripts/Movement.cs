﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour


{

    public float moveSpeed = 5f;
    public float hitPoints = 100f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if user has pressed some input keys
        //left right movement with arrow keys
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //Set animation to walking. 
            anim.SetTrigger("walking");

            // convert user input into world movement
            float horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
            float verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

            //assign movement to a single vector3
            Vector3 directionOfMovement = new Vector3(horizontalMovement, verticalMovement, 0);

            // apply movement to player's transform
            gameObject.transform.Translate(directionOfMovement);
        }
    }
}
