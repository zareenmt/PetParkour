using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public CanvasGroup fadePanel;

    private bool isPaused = false;
    public float fadeDuration = 1f;
    private bool musicPausedTransistion = false;
    private bool musicPlaying = false;

    private void Start() {
        optionsPanel.SetActive(false);
        fadePanel.alpha = 0f;
        fadePanel.blocksRaycasts = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }

        if (SceneManager.GetActiveScene().name == "MainScene" && !musicPausedTransistion && !musicPlaying) {
            BackgroundMusicManager musicManager = FindObjectOfType<BackgroundMusicManager>();
            if (musicManager != null) {
                AudioSource audioSource = musicManager.GetComponent<AudioSource>();
                if (audioSource != null && !audioSource.isPlaying) {
                    audioSource.Play();
                    musicPlaying = true;
                }
            }
        }
    }

    public void PauseGame() {
        isPaused = true;
        optionsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        isPaused = false;
        optionsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitToMainMenu() {
        Time.timeScale = 1f;
        BackgroundMusicManager musicManager = FindObjectOfType<BackgroundMusicManager>();
        if (musicManager != null) {
            AudioSource audioSource = musicManager.GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying) {
                audioSource.Pause();
                musicPausedTransistion = true;
            }
        }
        StartCoroutine(FadeScene(0));
    }

    private IEnumerator FadeScene(int scene) {
        fadePanel.blocksRaycasts = true;
        float elapsedTime = 0f;

        while(elapsedTime < fadeDuration) {
            float t = elapsedTime / fadeDuration;
            fadePanel.alpha = t;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(scene);
        fadePanel.blocksRaycasts = false;

        musicPausedTransistion = false;
    }
}
