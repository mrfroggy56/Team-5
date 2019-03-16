using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class DB_Options_Script : MonoBehaviour
{
    // Variables
    // Setting up a reference for the AudioMixer so we can edit Sound level
    public AudioMixer audioMixer;
    // Referencing the resolution dropdown UI component
    public Dropdown resolutionDropDown;
    // An array of resolutions we can use
    Resolution[] resolutions;

    public void Start()
    {
        //This is used to make sure we can access all of Unitys resolution options
        #region Resolution DropDown UI componet SetUp
        // The resolution array reference to the screen resolutions
        resolutions = Screen.resolutions;
        // We want to clear the references drop down so we can creat the rolsutions oursleves
        resolutionDropDown.ClearOptions();
        // List of strings which will be used to show our different resolutions
        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i <resolutions.Length; i++)
        {
            // We make our option variable carry the different resolutions and how they are shown on screen through strings
            string option = resolutions[i].width  + "x" + resolutions[i].height;
            // We add the different resolutions to our resolution array
            resolutionOptions.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(resolutionOptions);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
        #endregion
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
