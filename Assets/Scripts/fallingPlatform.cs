using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{

    private float fallDelay = .2f;
    private float destroyDelay = 2f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float mass = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.mass = mass;
        Destroy(gameObject, destroyDelay);
    }
}
