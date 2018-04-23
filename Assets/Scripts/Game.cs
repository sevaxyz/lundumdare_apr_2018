using System;
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
    private Text dudeColorText;
    private Text topColorText;


    // Use this for initialization
    void Awake()
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
        PrintScore();

        var timerGameObjList = GameObject.FindGameObjectsWithTag("TimerText");
        foreach (var timerGameObj in timerGameObjList)
        {
            timerText = timerGameObj.GetComponent<Text>();
        }

        var dudeColorGameObjList = GameObject.FindGameObjectsWithTag("DudeColorText");
        foreach (var dudeColorGameObj in dudeColorGameObjList)
        {
            dudeColorText = dudeColorGameObj.GetComponent<Text>();
        }

        var topColorGameObjList = GameObject.FindGameObjectsWithTag("TopColorText");
        foreach (var topColorGameObj in topColorGameObjList)
        {
            topColorText = topColorGameObj.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (!round.Finished)
            round.Tick(Time.deltaTime);
        PrintTime();
    }

    public void KillGuyInDoor(int doorNumber, bool isSentenced)
    {
        bool triggerred = false;
        bool isGuilty = false;
        if (doorNumber == 1 && door1.IsOccupied)
        {
            isGuilty = door1.GetCurrentGuy().isGuilty;
            triggerred = true;
            door1.KillGuy(isSentenced);
        }
        else if (doorNumber == 2 && door2.IsOccupied)
        {
            isGuilty = door2.GetCurrentGuy().isGuilty;
            triggerred = true;
            door2.KillGuy(isSentenced);
        }
        else if (doorNumber == 3 && door3.IsOccupied)
        {
            isGuilty = door3.GetCurrentGuy().isGuilty;
            triggerred = true;
            door3.KillGuy(isSentenced);
        }

        if (triggerred)
        {
            if (isGuilty && isSentenced)
            {
                Debug.Log("Correct!");
                round.CorrectKill();
            }
            else if ((!isGuilty) && (!isSentenced))
            {
                Debug.Log("Correct!");
                round.CorrectFree();
            }
            else
            {
                Debug.Log("Incorrect =(");
                round.IncorrectKill();
            }
            PrintScore();
        }
    }

    public Guy GenerateGuy()
    {
        var guyObj = generator.Generate();
        return guyObj.GetComponent<Guy>();
    }

    private void PrintTime()
    {
        timerText.text = string.Format("{0,2:D2}", (int) round.Time);
        // Debug.Log("Time: " + round.Time);
    }

    private void PrintScore()
    {
        scoreText.text = string.Format("{0,10:D6}", round.Score);
        // Debug.Log("Score: " + round.Score);
    }

    public void PrintGuiltyColors(string prohibitedSkin, string prohibitedDress)
    {
        dudeColorText.text = prohibitedSkin;
        topColorText.text = prohibitedDress;
    }
}
