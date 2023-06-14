using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleUnpause : MonoBehaviour
{
    public GameObject pause;
    public Rigidbody2D player_rb;


    public void unshowPause()
    {
        pause.SetActive(false);
        player_rb.bodyType = RigidbodyType2D.Dynamic;

    }
}
