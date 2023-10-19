using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;



    void Start()
    {
        resolutionDropdown.ClearOptions();

        Resolution[] resolutions = Screen.resolutions;
        List<string> options = new List<string>();

        foreach (Resolution res in resolutions)
        {
            if (res.refreshRate == 60)
            {
                string option = res.width + "x" + res.height + " @" + res.refreshRate + "Hz";
                if (!options.Contains(option))
                {
                    options.Add(option);
                }
            }
        }

        resolutionDropdown.AddOptions(options);
    }

    public void SetResolutionFromDropdown(int index)
    {
        Resolution[] resolutions = Screen.resolutions;
        Resolution selectedResolution = resolutions[index];

        Screen.SetResolution(selectedResolution.width, selectedResolution.height, true);
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

}
