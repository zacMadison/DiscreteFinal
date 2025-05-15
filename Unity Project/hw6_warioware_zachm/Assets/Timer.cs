using System;
using System.Globalization;
using global;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeLimit;
    [SerializeField] private TextMeshProUGUI timerText;
    void Start()
    {
        timeLimit = timeLimit / GameManager.Instance.speed;
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;
        if (timeLimit < 0)
        {
            SceneManager.LoadScene("Transition");
        }
        else
        {
            double currentTime = timeLimit;
            currentTime = Math.Round(currentTime, 1);
            timerText.text = currentTime.ToString(CultureInfo.CurrentCulture);

        }
    }
    
    
}
