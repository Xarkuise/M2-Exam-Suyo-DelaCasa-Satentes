using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootController : MonoBehaviour
{
    public Transform shootSpawnPoint;
    public GameObject shootPrefab;
    public int maxShells = 1;
    private int currentShells = 0;
    private bool canFire = false;
    public AudioSource fireSoundSource;
    public AudioClip fireSoundClip;
    public TextMeshProUGUI shootText;


    void OnTriggerEnter(Collider getShell)
    {
        if (getShell.gameObject.tag == "ItemBox")
        {
            if (currentShells < maxShells)
            {
                currentShells++;

                //Debug.Log("Shell Lock and Loaded!");

                canFire = true;

            }
        }
    }

    void Update()
    {
        if (canFire && Input.GetKeyDown(KeyCode.Space))
        {
            FireShell();
            playFireSound();
        }
    }

    void FireShell()
    {
        Vector3 forwardDirection = transform.forward;

        GameObject shell = Instantiate(shootPrefab, shootSpawnPoint.position, Quaternion.identity);
        shell.transform.Rotate(90f, 0f, 0f, Space.Self);
            
        Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();

        // Apply a force in the forward direction
        if (shellRigidbody != null)
        {
            float shellSpeed = 30f; // Adjust the speed as needed
            shellRigidbody.AddForce(forwardDirection * shellSpeed, ForceMode.VelocityChange);
        }

        
        currentShells--;

        //Debug.Log("PEW PEW! Shells: " + currentShells);

        canFire = (currentShells > 0);
    }

    void playFireSound()
    {
        if (fireSoundSource != null && fireSoundClip != null)
        {
            fireSoundSource.clip = fireSoundClip;
            fireSoundSource.Play();
        }
    }
}
