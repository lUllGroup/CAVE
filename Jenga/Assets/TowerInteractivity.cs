﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInteractivity : MonoBehaviour
{

    private GameObject selectedObj = null;

    public float force;


    // Use this for initialization
    void Start()
    {
        force = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("1");
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("2");
                if (hitInfo.transform.gameObject.tag == "Brick")
                {
                    Debug.Log("It's working!");

                    if (selectedObj != null)
                    {
                        selectedObj.GetComponent<Renderer>().material.color = Color.green;
                    }

                    selectedObj = hitInfo.transform.gameObject;

                    Debug.Log("Name_" + selectedObj.name);
                    selectedObj.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (selectedObj != null)
        {
            Rigidbody rigidbody = selectedObj.GetComponent<Rigidbody>();

            // as of now, only the cubes with the "+" material have this script, so only they move!
            Vector3 moveVector = new Vector3();
            // up
            if (Input.GetKey(KeyCode.Y))
            {
                //rigidbody.velocity = new Vector3(0, force, 0);
                moveVector.y = force;
            }

            // down
            if (Input.GetKey(KeyCode.X))
            {
                //rigidbody.velocity = new Vector3(0, -force, 0);
                moveVector.y = -force;
            }

            // forward
            if (Input.GetKey(KeyCode.W))
            {
                //rigidbody.velocity = new Vector3(0, 0, force);
                moveVector.z = force;
            }

            // backward
            if (Input.GetKey(KeyCode.S))
            {
                //rigidbody.velocity = new Vector3(0, 0, -force);
                moveVector.z = -force;
            }

            // left
            if (Input.GetKey(KeyCode.A))
            {
                //rigidbody.velocity = new Vector3(-force, 0, 0);
                moveVector.x = -force;
            }

            // right
            if (Input.GetKey(KeyCode.D))
            {
                //rigidbody.velocity = new Vector3(force, 0, 0);
                moveVector.x = force;
            }

            // if no force is applied, dont change velocity (so gravity can work)
            if (moveVector.sqrMagnitude > 0)
            {
                rigidbody.velocity = moveVector;
            }
        }


    }
}
