using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Key 1 pressed");
            Game.Instance.KillGuyInDoor(1, true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Key 2 pressed");
            Game.Instance.KillGuyInDoor(2, true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Key 3 pressed");
            Game.Instance.KillGuyInDoor(3, true);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Key 1 pressed");
            Game.Instance.KillGuyInDoor(1, false);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Key 2 pressed");
            Game.Instance.KillGuyInDoor(2, false);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Key 3 pressed");
            Game.Instance.KillGuyInDoor(3, false);
        }
        else if (Input.GetKey("escape"))
            Application.Quit();
    }
}
