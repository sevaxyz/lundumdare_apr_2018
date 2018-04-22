using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    
    void Start ()
    {
        GameObject.FindGameObjectsWithTag("Door1");
        GameObject.FindGameObjectsWithTag("Door2");
        GameObject.FindGameObjectsWithTag("Door3");
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown("1"))
        {

        }
        else if (Input.GetKeyDown("2"))
        {

        }
        else if (Input.GetKeyDown("3"))
        {

        }
    }
}
