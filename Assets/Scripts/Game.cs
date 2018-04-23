using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : Singleton<Game> {

    private GuyGenerator generator;
    Door door1 = null;
    Door door2 = null;
    Door door3 = null;

    public Round round;

    private Text scoreText;
    private Text timerText;

    // Use this for initialization
    void Start()
    {
        round = new Round();
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

        var scoreGameObjList = GameObject.FindGameObjectsWithTag("ScoreText");
        foreach (var scoreGameObj in scoreGameObjList)
        {
            scoreText = scoreGameObj.GetComponent<Text>();
        }

        var timerGameObjList = GameObject.FindGameObjectsWithTag("TimerText");
        foreach (var timerGameObj in timerGameObjList)
        {
            timerText = timerGameObj.GetComponent<Text>();
        }

        PrintScore();
    }

    // Update is called once per frame
    void Update ()
    {

    }

    public void KillGuyInDoor(int doorNumber, bool isGuilty)
    {
        Guy guy = null;
        if (doorNumber == 1 && door1.IsOccupied)
        {
            door1.KillGuy(isGuilty);
            guy = door1.GetCurrentGuy();
        }
        else if (doorNumber == 2 && door2.IsOccupied)
        {
            door2.KillGuy(isGuilty);
            guy = door2.GetCurrentGuy();
        }
        else if (doorNumber == 3 && door3.IsOccupied)
        {
            door3.KillGuy(isGuilty);
            guy = door3.GetCurrentGuy();
        }
        if (guy)
        {
            if (guy.isGuilty && isGuilty)
                round.CorrectKill();
            if (!guy.isGuilty && !isGuilty)
                round.CorrectFree();
            else
                round.IncorrectKill();
            PrintScore();
        }
    }

    public Guy GenerateGuy()
    {
        var guyObj = generator.Generate();
        return guyObj.GetComponent<Guy>();
    }

    private void PrintScore()
    {
        scoreText.text = string.Format("{0,10:D6}", round.Score);
        Debug.Log("Score: " + round.Score);
    }
}
