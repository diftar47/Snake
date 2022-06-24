using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject deadCanvas;
    //public GameObject pauseCanvas;
    public GameObject mainCanvas;

    private void Start()
    {
        deadCanvas.SetActive(false);
        //pauseCanvas.SetActive(false);
        mainCanvas.SetActive(true);

        WallTriger.DeadEvent.AddListener(Dead);
    }

    public void Dead()
    {
        mainCanvas.SetActive(false);
        deadCanvas.SetActive(true);
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
