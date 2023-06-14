using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int counter = 0;

    [SerializeField] private TextMeshProUGUI KiwiText;
    [SerializeField] private AudioSource collectSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Kiwi"))
        {
            collectSFX.Play(); 
            Destroy(collision.gameObject);
            counter++;
            KiwiText.text = "Kiwi: " + counter;
        }
    }
}
