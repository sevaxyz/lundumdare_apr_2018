using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round
{
    public int Score { get; set; }

    public Round()
    {
        Score = 0;
    }

    public void Flush()
    {
        Score = 0;
    }

    public void CorrectKill()
    {
        Score += 10;
    }

    public void CorrectFree()
    {
        Score += 2;
    }

    public void IncorrectKill()
    {
        if (Score >= 10)
            Score -= 10;
        else
            Score = 0;
    }

}
