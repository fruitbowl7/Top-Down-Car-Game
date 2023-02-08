using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Awake()
    {
       
    }
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }

    public void ReplayButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButtonPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PauseButtonPressed()
    {
        Time.timeScale = 0;
        //PausePanel.SetActive(true);
    }

    public void PlayButtonPressed()
    {
        Time.timeScale =1;
       // PausePanel.SetActive(false);
    }
}
