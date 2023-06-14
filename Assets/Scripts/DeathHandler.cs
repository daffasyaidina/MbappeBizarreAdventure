using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    private Rigidbody2D player_rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSFX;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player_rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    
    private void Die()
    {
        deathSFX.Play();
        anim.SetTrigger("dead");
        player_rb.bodyType = RigidbodyType2D.Static;
    }

    private void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
