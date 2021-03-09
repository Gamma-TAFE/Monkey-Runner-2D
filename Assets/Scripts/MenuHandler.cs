using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public AudioMixer masterAudio;

    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat("volume", volume);
    }
    
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ToggleMute(bool isMuted)
    {
        if(isMuted)
        {
            masterAudio.SetFloat("isMutedVolume", -80);
        }
        else
        {
            masterAudio.SetFloat("isMutedVolume", 0);
        }
    }
    
    public void ExitToDesktop()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();



    }

    public void Quality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public Resolution[] resolutions;
    public Dropdown resolution;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width
                + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width 
                ==  Screen.currentResolution.width && resolutions[i].height  == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }
        resolution.AddOptions(options);
        resolution.value = currentResolutionIndex;
        resolution.RefreshShownValue();
        
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);

    }
}
