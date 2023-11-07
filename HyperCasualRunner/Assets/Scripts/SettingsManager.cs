using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] VibrationsManager _vibrationsManager;
    [SerializeField] SoundManager _soundManager;
    [SerializeField] Sprite _optionOffSrite;
    [SerializeField] Sprite _optionOnSrite;
    [SerializeField] Image _soundButtonImage;
    [SerializeField] Image _vibrationButtonImage;

    bool _soundState = true;
    bool _vibrationState = true;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
        _soundState = PlayerPrefs.GetInt("sounds",1) == 1;
        _vibrationState = PlayerPrefs.GetInt("vibrations",1) == 1;

    }

    private void Setup()
    {
        if(_soundState)
            EnableSound();
        else
            DisableSound();

        if(_vibrationState)
            EnableVibration();
        else
            DisableVibration();
    }
    public void ChangeSoundState()
    {
        if(_soundState)
            DisableSound();
        else
            EnableSound();

        _soundState = !_soundState;

        PlayerPrefs.SetInt("sounds", _soundState? 1:0);

    }

    private void EnableSound()
    {
        _soundButtonImage.sprite = _optionOnSrite;
        _soundManager.EnableSounds();

    }

    private void DisableSound()
    {
        _soundButtonImage.sprite = _optionOffSrite;
        _soundManager.DisableSounds();
    }

    public void ChangeVibrationState()
    {
        if(_vibrationState)
            DisableVibration();
        else
            EnableVibration();

        _vibrationState = !_vibrationState;
        PlayerPrefs.SetInt("vibrations", _soundState? 1:0);


    }

    public void EnableVibration()
    {
        _vibrationButtonImage.sprite = _optionOnSrite;
        _vibrationsManager.EnableVibration();
    }


    public void DisableVibration()
    {
        _vibrationButtonImage.sprite = _optionOffSrite;
        _vibrationsManager.DisableVibration();
    }














}
