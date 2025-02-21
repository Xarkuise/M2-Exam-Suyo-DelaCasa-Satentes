using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireWallCollision : MonoBehaviour
{
    public AudioClip collisionSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = collisionSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collisionSound != null)
            {
                audioSource.Play();
            }
        }
    }
}
