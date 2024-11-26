using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject optionsOverlay;

    public void onPlayButton() {
        SceneManager.LoadScene(1);
    }
    
    public void onExitButton() {
        Application.Quit();
    }

    public void onOptionsButtonOpen() {
        optionsOverlay.SetActive(true);
    }

    public void onOptionsButtonClose() {
        optionsOverlay.SetActive(false);
    }
}
