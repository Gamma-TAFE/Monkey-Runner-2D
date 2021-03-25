using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class InGameUI : MonoBehaviour
{
    public Text boostText;
    public bool speed = false;
    public bool jump = false;
    public float timeStart;
    public Text timerText;
    public Text timerTextGameOver;

    void Start()
    {
        timerText.text = timeStart.ToString("F2");
    }

    private void Update()
    {
        if (jump == true && speed == true)
        {
            boostText.text = "Speed + Jump";
        }
        else if (speed == true && jump == false)
        {
            boostText.text = "Speed";
        }
        else if (speed == false && jump == true)
        {
            boostText.text = "Jump";
        }
        else
        {
            boostText.text = "None";
        }

        timeStart += Time.deltaTime;
        timerText.text = timeStart.ToString("F2");
        if (Time.timeScale == 0)
        {
            timerTextGameOver.text = timeStart.ToString("F2");
        }
    }
}
