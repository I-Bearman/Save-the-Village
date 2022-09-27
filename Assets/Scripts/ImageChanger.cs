using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Sprite newSprite;
    public AudioClip clip;

    private Image img;
    private AudioSource audio;
    void Start()
    {
        img = GetComponent<Image>();
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void ChangeSprite()
    {
        img.sprite = newSprite;
        img.SetNativeSize();
    }

    public void ChangeColor()
    {
        img.color = Color.magenta;
    }

    public void ChangeSoundPlay()
    {
        if (audio.isPlaying)
            audio.Pause();
        else
            audio.Play();
    }

    public void ChangeSound()
    {
        audio.clip = clip;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
