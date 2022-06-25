using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject deadCanvas;
    public GameObject mainCanvas;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreText2;

    //FoodGeneration foodGeneration = new FoodGeneration();

    private void Start()
    {
        deadCanvas.SetActive(false);
        mainCanvas.SetActive(true);

        scoreText.text = string.Format("Score: {0}", FoodGeneration.Score);

        WallTriger.DeadEvent.AddListener(Dead);
        FoodGeneration.Eating.AddListener(Eating);
    }

    private void Eating()
    {
        scoreText.text = string.Format("Score: {0}", FoodGeneration.Score);
    }

    public void Dead()
    {
        mainCanvas.SetActive(false);
        deadCanvas.SetActive(true);
        scoreText2.text = string.Format("Score: {0}", FoodGeneration.Score);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
