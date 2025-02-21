using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public GameObject itemBox;
    public float respawnDelay = 3f;
    public AudioSource boxSoundSource;
    public AudioClip boxSoundClip;

    private bool isBoxSpawned = false;

    void Start()
    {
        SpawnBox();
        StartCoroutine(SpawnBoxRoutine());
    }

    IEnumerator SpawnBoxRoutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => !isBoxSpawned);
            yield return new WaitForSeconds(respawnDelay);

            SpawnBox();
        }
    }

    void SpawnBox()
    {
        //Debug.Log("Box has Spawned");
        Instantiate(itemBox, transform.position, transform.rotation);
        isBoxSpawned = true;
    }

    void OnTriggerEnter(Collider boxTrigger)
    {
        if (boxTrigger.gameObject.tag == "Player")
        {
            BoxDestroyed();
            boxGetSound();
        }
    }

    public void BoxDestroyed()
    {
        isBoxSpawned = false;
    }

    void boxGetSound()
    {
        if (boxSoundSource != null && boxSoundClip != null)
        {
            boxSoundSource.clip = boxSoundClip;
            boxSoundSource.Play();
        }
    }

   
}

