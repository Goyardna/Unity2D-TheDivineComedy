using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_collector : MonoBehaviour
{
    private int collections = 0;
    [SerializeField] private Text collectionsText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collection"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            collections++;
            collectionsText.text = "ÓðÃ«: " + collections;
        }
    }
}
