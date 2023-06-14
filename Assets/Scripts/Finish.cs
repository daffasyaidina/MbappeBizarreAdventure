using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource FinishSFX;
    public Rigidbody2D player_rb;
    private bool levelCompleted = false;
    public GameObject ScorePanel;

    // Start is called before the first frame update
    private void Start()
    {
        FinishSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chara" && !levelCompleted)
        {
            FinishSFX.Play();
            levelCompleted = true;
            player_rb.bodyType = RigidbodyType2D.Static;
            Invoke("showPanel", 2f);
        }
    }

    private void showPanel()
    {
        ScorePanel.SetActive(true);
    }
}
