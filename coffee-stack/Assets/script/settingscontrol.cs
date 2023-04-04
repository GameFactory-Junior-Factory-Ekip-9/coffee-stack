using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingscontrol : MonoBehaviour
{
    public bool sound;
    public bool vibration;
    public GameObject settings;
    public GameObject soundon;
    public GameObject vibrationon;
    public GameObject soundoff;
    public GameObject vibrationoff;
    private void Update()
    {
        soundon.SetActive(sound);
        soundoff.SetActive(!sound);
        vibrationon.SetActive(vibration);
        vibrationoff.SetActive(!vibration);
    }
    public void opensettings() 
    {
        settings.SetActive(true);
    }
    public void closesettings() 
    {
        settings.SetActive(false);
    }
    public void settingsound(){ sound =! sound; }
    public void settingvibration() { vibration = !vibration; }
}
