using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Guy guy = null;

    public bool IsOccupied { set; get; }

    // Use this for initialization
    void Start ()
    {
        IsOccupied = false;
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    public void AssingGuy(Guy guy)
    {
        if (!IsOccupied)
        {
            this.guy = guy;
            IsOccupied = true;
        }
    }

    public void KillGuy()
    {
        if (IsOccupied && guy)
        {
            guy.Die();
            guy = null;
            IsOccupied = false;
        }
    }
}
