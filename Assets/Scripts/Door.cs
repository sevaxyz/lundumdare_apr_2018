using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float idleTimeTotal;
    private float idleTimeLeft;
    private bool isIdle = false;

    public float waitingToCreateGuyTotal;
    private float waitingToCreateGuyTimeLeft;
    private bool isWaitingToCreate = false;

    private bool isKillingInProgress = false;

    private AudioSource audioSource = null;

    private Guy guy = null;

    private bool isOccupied = false;

    Animator animator;

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
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (isIdle)
        {
            idleTimeLeft -= Time.deltaTime;
            if (idleTimeLeft < 0)
            {
                isIdle = false;
                DestroyGuy();
                StartWaitingToCreateTimer();
            }
        }
        else if (isWaitingToCreate)
        {
            waitingToCreateGuyTimeLeft -= Time.deltaTime;
            if (waitingToCreateGuyTimeLeft < 0)
            {
                isWaitingToCreate = false;
                CreateNewGuy();
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("DoorClosed"))
        {
            DestroyGuy();
            OpenTheDoorAnimation();
            StartWaitingToCreateTimer();
        }
    }

    public void AssingGuy(Guy guy)
    {
        if (!IsOccupied)
        {
            guy.transform.position = transform.position;
            this.guy = guy;
            IsOccupied = true;
            StartIdleTimer();
        }
    }

    public bool KillGuy(bool isGuilty)
    {
        bool res = false;
        if (IsOccupied && guy && !isKillingInProgress)
        {
            res = true;
            if (isGuilty)
            {
                isIdle = false;
                isKillingInProgress = true;
                CloseTheDoorAnimation();
                audioSource.clip = Resources.Load<AudioClip>("Sounds/jail_cell_door");
                audioSource.Play();
            }
            else
            {
                audioSource.clip = Resources.Load<AudioClip>("Sounds/choir");
                audioSource.Play();
                DestroyGuy();
                StartWaitingToCreateTimer();
            }
        }
        return res;
    }

    private void DestroyGuy()
    {
        guy.Die();
        guy = null;
        IsOccupied = false;
        isIdle = false;
        isKillingInProgress = false;
    }

    public void StartWaitingToCreateTimer()
    {
        waitingToCreateGuyTimeLeft = waitingToCreateGuyTotal;
        isWaitingToCreate = true;
    }

    public void StartIdleTimer()
    {
        idleTimeLeft = idleTimeTotal;
        isIdle = true;
    }

    private void CloseTheDoorAnimation()
    {
        animator.SetBool("CloseDoor", true);
        animator.SetBool("OpenDoor", false);
    }

    private void OpenTheDoorAnimation()
    {
        animator.SetBool("CloseDoor", false);
        animator.SetBool("OpenDoor", true);
    }

    private void CreateNewGuy()
    {
        var newGuy = Game.Instance.GenerateGuy();
        AssingGuy(newGuy);
    }

    public Guy GetCurrentGuy()
    {
        return guy;
    }
}
