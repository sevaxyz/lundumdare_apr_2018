using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round
{
    static Round _instance = null;

    public int Score { get; set; }
    public float Time { get; set; } // in seconds
    public bool Finished { get; set; }

    private Round()
    {
        Flush();
    }

    public static Round Instance()
    {
        if (_instance == null)
        {
            _instance = new Round();
        }
        return _instance;
    }

    public void Flush()
    {
        Score = 0;
        Time = 5;
        Finished = false;
    }

    public void CorrectKill()
    {
        if (!Finished)
            Score += 10;
    }

    public void CorrectFree()
    {
        if (!Finished)
            Score += 2;
    }

    public void IncorrectKill()
    {
        if (!Finished)
        {
            Debug.Log("In IncorrectKill: inside!");
            if (Score >= 10)
                Score -= 10;
            else
                Score = 0;
        }
    }

    public void Tick(float delta)
    {
        Time -= delta;
        if (Time <= 0)
        {
            Time = 0;
            Finished = true;
        }
    }

}
