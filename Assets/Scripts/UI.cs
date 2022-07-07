using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject deadCanvas;
    public GameObject mainCanvas;
    public GameObject pauseCanvas;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreText2;

    [SerializeField] private AudioSource eatingSource;
    [SerializeField] private AudioSource backgroundMusic;

    //FoodGeneration foodGeneration = new FoodGeneration();

    private void Start()
    {
        deadCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        mainCanvas.SetActive(true);

        scoreText.text = string.Format("Score: {0}", FoodGeneration.Score);

        WallTriger.DeadEvent.AddListener(Dead);
        FoodGeneration.Eating.AddListener(Eating);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (deadCanvas.activeSelf == false))
            Pause();
        
        if(deadCanvas.activeSelf == true)
            backgroundMusic.Stop();

        if (pauseCanvas.activeSelf == true)
            backgroundMusic.volume = 0.1f;
        else
            backgroundMusic.volume = 1;
    }

    private void Eating()
    {
        scoreText.text = string.Format("Score: {0}", FoodGeneration.Score);
        eatingSource.Play();
    }

    public void Dead()
    {
        mainCanvas.SetActive(false);
        deadCanvas.SetActive(true);
        scoreText2.text = string.Format("Score: {0}", FoodGeneration.Score);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }

}
