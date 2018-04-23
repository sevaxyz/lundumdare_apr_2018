using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float idleTime;
    private float idleTimeLeft;
    private bool isWaiting = false;

    private float waitingToCreateGuyTimeLeft;
    private bool isWaitingToCreate = false;

    private AudioSource audioSource = null;

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
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (isWaiting)
        {
            idleTimeLeft -= Time.deltaTime;
            if (idleTimeLeft < 0)
            {
                DestroyGuy();
                OnWaitingToCreateTimer();
            }
        }
        else if (isWaitingToCreate)
        {
            waitingToCreateGuyTimeLeft -= Time.deltaTime;
            if (waitingToCreateGuyTimeLeft < 0)
            {
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
            if (isGuilty)
            {
                audioSource.clip = Resources.Load<AudioClip>("Sounds/jail_cell_door");
                audioSource.Play();
            }
            else
            {
                audioSource.clip = Resources.Load<AudioClip>("Sounds/choir");
                audioSource.Play();
            }
            DestroyGuy ();
        }
    }

    private void DestroyGuy()
    {
        guy.Die();
        guy = null;
        IsOccupied = false;
        isWaiting = false;
    }

    public void OnWaitingToCreateTimer()
    {
        isWaitingToCreate = true;
        waitingToCreateGuyTimeLeft = 1;
    }
}
