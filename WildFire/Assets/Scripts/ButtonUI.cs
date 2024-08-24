using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    private AudioGame audioGame;
    [SerializeField] private int isPlayMusic;
    [SerializeField] private int isPlaySFX;
    [SerializeField] private GameObject imageMusic;
    [SerializeField] private GameObject imageSFX;
    
    private void Start()
    {
        audioGame = FindObjectOfType<AudioGame>();
        isPlayMusic = PlayerPrefs.GetInt("music", 1);
        isPlaySFX = PlayerPrefs.GetInt("sfx", 1);
        if (isPlayMusic == 1)
        {
            if(imageMusic == null) { return;}
            imageMusic.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/ICON/ICON/musicOn");
        }
        else 
        {
            if(imageMusic == null) { return;}
            imageMusic.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/ICON/ICON/musicOff");
        }
    }

    


    public void Music()
    {
        if (isPlayMusic == 1)
        {
            isPlayMusic = 0;
            if(imageMusic == null) { return;}
            PlayerPrefs.SetInt("music", isPlayMusic);
            imageMusic.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/ICON/ICON/musicOff");
            audioGame.GetComponent<AudioSource>().volume = 0f;
        }
        else 
        {
            isPlayMusic = 1;
            if(imageMusic == null) { return;}
            PlayerPrefs.SetInt("music", isPlayMusic);
            imageMusic.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/ICON/ICON/musicOn");
            audioGame.GetComponent<AudioSource>().volume = 1f;
        }
    }
    
    public void SFX()
    {
        if (isPlaySFX == 1)
        {
            isPlaySFX = 0;
            if(imageSFX == null) { return;}
            imageSFX.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/ICON/ICON/audioOff");
            audioGame.shootingVolume = 0f;
            audioGame.damageVolume = 0f;
        }
        else
        {
            isPlaySFX = 1;
            if(imageSFX == null) { return;}
            imageSFX.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/ICON/ICON/audioOn");
            audioGame.shootingVolume = 1f;
            audioGame.damageVolume = 1f;
        }
    }
}
