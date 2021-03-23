using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject optionsPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeInHierarchy == false && optionsPanel.activeInHierarchy == false)
            {
                Time.timeScale = 0;
                pausePanel.gameObject.SetActive(true);
            }
            else
            {
                Unpause();
            }
                
        }
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pausePanel.gameObject.SetActive(false);
        optionsPanel.gameObject.SetActive(false);
    }
}
