using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game> {

    List<Door> doorList = new List<Door>();
    private GuyGenerator generator;
    Door door1 = null;
    Door door2 = null;
    Door door3 = null;

    // Use this for initialization
    void Start ()
    {
        generator = GetComponent<GuyGenerator>();

        var doorGameObjList = GameObject.FindGameObjectsWithTag("Door");
        foreach (var doorGameObj in doorGameObjList)
        {
            var comp = doorGameObj.GetComponent<Door>();
            if (comp)
            {
                var guyObj = generator.Generate();
                comp.AssingGuy(guyObj.GetComponent<Guy>());
                if (doorGameObj.name == "Door1")
                    door1 = comp;
                else if (doorGameObj.name == "Door2")
                    door2 = comp;
                else if (doorGameObj.name == "Door3")
                    door3 = comp;
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {

    }

    public void KillGuyInDoor(int doorNumber, bool isGuilty)
    {
        if (doorNumber == 1 && door1.IsOccupied)
        {
            door1.KillGuy(isGuilty);
            door1.OnWaitingToCreateTimer();
        }
        else if (doorNumber == 2 && door2.IsOccupied)
        {
            door2.KillGuy(isGuilty);
            door2.OnWaitingToCreateTimer();
        }
        else if (doorNumber == 3 && door3.IsOccupied)
        {
            door3.KillGuy(isGuilty);
            door3.OnWaitingToCreateTimer();
        }
    }

    public Guy GenerateGuy()
    {
        var guyObj = generator.Generate();
        return guyObj.GetComponent<Guy>();
    }
}
