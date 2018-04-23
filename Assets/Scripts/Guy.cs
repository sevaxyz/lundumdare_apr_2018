using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    public bool isGuilty { get; set; }

    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
