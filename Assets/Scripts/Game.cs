using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game> {

    public GameObject GuyPrefab;
    List<Door> doorList = new List<Door>();
    private GuyGenerator generator;

    // Use this for initialization
    void Start ()
    {
        Screen.SetResolution(640, 480, false);

        generator = GetComponent<GuyGenerator>();

        var doorGameObjList = GameObject.FindGameObjectsWithTag("Door");
        foreach (var doorGameObj in doorGameObjList)
        {
            var comp = doorGameObj.GetComponent<Door>();
            if (comp)
            {
                var guyObj = generator.Generate();
                guyObj.transform.position = comp.transform.position;
                comp.AssingGuy(guyObj.GetComponent<Guy>());
                doorList.Add(comp);
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {

    }

    public void KillGuyInDoor(int doorNumber)
    {
        if (doorNumber <= doorList.Count)
            doorList[doorNumber - 1].KillGuy();
    }
}
