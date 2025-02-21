using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int index;

    public GameObject[] cars;

    private void Start()
    {
        index = PlayerPrefs.GetInt("carIndex");

        GameObject car = Instantiate(cars[index], Vector3.zero, Quaternion.identity);

        car.transform.position = new Vector3(-39.406f, -79.90f, 312.499f);

        if (index == 0) {
            car.transform.Rotate(0f, 180f, 0.0f, Space.Self);
            car.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
           
        }

        if (index == 1) {
            car.transform.Rotate(0f, 180f, 0.0f, Space.Self);
            car.transform.localScale = new Vector3(0.47f, 0.47f, 0.47f);
           
        }

        if (index == 2) {
            car.transform.Rotate(0f, 180f, 0.0f, Space.Self);
            car.transform.localScale = new Vector3(0.006f, 0.006f, 0.006f);

        }
    }
}
