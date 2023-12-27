using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreneSettings : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject resumePanel;
    [SerializeField] private GameObject tapEffect;

    public void PauseButtonPressed()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ContinueButtonPressed()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ChengeScene(int scene)
    {
        Debug.Log("wcsc");
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButtonPressed();
        }
    }
}
