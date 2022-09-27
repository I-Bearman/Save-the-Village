using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public AudioSource Sound, PauseSound, ClickSound;
    public GameObject PauseScreen;
    private bool paused;
    public void PauseGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            Sound.Play();
            PauseSound.Pause();
            PauseScreen.SetActive(false);
            ClickSound.Play();
        }
        else
        {
            Time.timeScale = 0;
            Sound.Pause();
            PauseSound.Play();
            PauseScreen.SetActive(true);
            ClickSound.Play();
        }
        paused = !paused;
    }
}
