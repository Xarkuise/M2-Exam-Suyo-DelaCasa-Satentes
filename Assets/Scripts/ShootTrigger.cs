using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrigger : MonoBehaviour
{
    private float delayDestroy = 5f;

    void Start()
    {
        Destroy(gameObject, delayDestroy);
    }

    void OnCollisionEnter(Collision shellCollided)
    {
        if(shellCollided.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
