using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
   
    
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex)
    }
    
    public void ExitToDesktop()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit()



    }
    
    
}
