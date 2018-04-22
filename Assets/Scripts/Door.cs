using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
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
        
    }

    public void AssingGuy(Guy guy)
    {
        if (!IsOccupied)
        {
            guy.transform.position = transform.position;
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
