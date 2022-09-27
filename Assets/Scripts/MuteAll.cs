using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAll : MonoBehaviour
{
    public Image MuteImage;
    public Sprite SoundOffSprite, SoundOnSprite;
    public void MuteClick()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            MuteImage.sprite = SoundOffSprite;
        }
        else
        {
            AudioListener.volume = 1;
            MuteImage.sprite = SoundOnSprite;
        }
        
    }
}
