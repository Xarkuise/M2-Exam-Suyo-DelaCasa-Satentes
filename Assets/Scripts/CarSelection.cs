using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    public GameObject[] cars;  // Array of cars
    public Button next;
    public Button prev;

    int index;

    void Start()
    {
        index = PlayerPrefs.GetInt("carIndex", 0); // Default to first car if no value is set
        UpdateCarDisplay();
    }

    void Update()
    {
        next.interactable = index < cars.Length - 1;
        prev.interactable = index > 0;
    }

    void UpdateCarDisplay()
    {
        index = Mathf.Clamp(index, 0, cars.Length - 1);

        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(i == index);
        }
    }

    public void Next()
    {
        index++;
        UpdateCarDisplay();
        PlayerPrefs.SetInt("carIndex", index);
        PlayerPrefs.Save();
    }

    public void Prev()
    {
        index--;
        UpdateCarDisplay();
        PlayerPrefs.SetInt("carIndex", index);
        PlayerPrefs.Save();
    }

    public void Race()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
}
