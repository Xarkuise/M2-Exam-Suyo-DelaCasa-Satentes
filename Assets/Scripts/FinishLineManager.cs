using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishLineManager : MonoBehaviour
{
    public int totalLaps = 3;
    private int currentLap = 0;
    public TextMeshProUGUI lapCounterText;

    void OnTriggerEnter(Collider lapDone)
    {
        if (lapDone.gameObject.tag == "Player")
        {
            currentLap++;
            Debug.Log("Current Lap: " + currentLap + "/3");

            if (lapCounterText != null)
            {
                lapCounterText.text = "Lap: " + currentLap + "/" + totalLaps;
            }

            if (currentLap >= 4)
            {
                Debug.Log("You Win");
                SceneManager.LoadSceneAsync("EndScreen");
            }
        }   
    }
}
