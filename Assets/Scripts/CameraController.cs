using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target = null;
	  public GameObject Cam = null;
	  public float speed = 1.5f;

    void Start()
    {

    }

    void Update() 
    {
        Target = GameObject.FindGameObjectWithTag("Player");
		    Cam = GameObject.FindGameObjectWithTag("Target");
    }

  
    void FixedUpdate()
    {
		  this.transform.LookAt(Target.transform);
		  float car_Move = Mathf.Abs(Vector3.Distance(this.transform.position, Cam.transform.position) * speed);
		  this.transform.position = Vector3.MoveTowards(this.transform.position, Cam.transform.position, car_Move * Time.deltaTime);
    }

}
