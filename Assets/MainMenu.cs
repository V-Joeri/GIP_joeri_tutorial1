using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource src;
    public AudioClip interact;

    public void PlayGame()
    {
        src.clip = interact;
        src.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        src.clip = interact;
        src.Play();
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
