using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float idleTime;
    private float idleTimeLeft;
    private bool isWaiting = false;

    private Guy guy = null;

    private bool isOccupied = false;

    public bool IsOccupied
    {
        get
        {
            return isOccupied;
        }
        set
        {
            Debug.Log(value);
            isOccupied = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        if (isWaiting)
        {
            idleTimeLeft -= Time.deltaTime;
            if (idleTimeLeft < 0)
            {
                KillGuy();
                var newGuy = Game.Instance.GenerateGuy();
                AssingGuy(newGuy);
            }
        }
    }

    public void AssingGuy(Guy guy)
    {
        if (!IsOccupied)
        {
            guy.transform.position = transform.position;
            this.guy = guy;
            IsOccupied = true;
            idleTimeLeft = idleTime;
            isWaiting = true;
        }
    }

    public void KillGuy(bool isGuilty = false)
    {
        if (IsOccupied && guy)
        {
            guy.Die();
            guy = null;
            IsOccupied = false;
            isWaiting = false;
        }
    }
}
