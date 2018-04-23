using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round
{
    public int Score { get; set; }
    
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

    public float Time { get; set; } // in seconds
    public bool Finished { get; set; }

    public void Tick(float delta)
    {
        Time -= delta;
        if (Time <= 0)
            Finished = true;
    }

    public void Flush()
    {
        Score = 0;
        Time = 60;
        Finished = false;
    }

    public Round()
    {
        Flush();
    }

}
