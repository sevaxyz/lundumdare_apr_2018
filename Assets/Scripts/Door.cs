using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject guyPrefab;
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

    public void SpawnGuy()
    {
        if (!IsOccupied)
        {
            // TODO Create Guy With GuyGenerator
            var guyGameObj = Instantiate(guyPrefab);
            guy = guyGameObj.GetComponent<Guy>();
            IsOccupied = true;
        }
    }

    public void KillGuy()
    {
        if (IsOccupied && guy)
        {
            guy.KillSelf();
            guy = null;
            IsOccupied = false;
        }
    }
}
