using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handlePause : MonoBehaviour
{
    public GameObject pause;
    public Rigidbody2D player_rb;

    public void showPause()
    {    
        pause.SetActive(true);
        player_rb.bodyType = RigidbodyType2D.Static;
        
    }


}
