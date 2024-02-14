using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public UnityEngine.UI.Image backgroundImage; // Microsoft.Unity.VisualStudio.Editor was giving an error
    public UnityEngine.UI.Image brightnessImage; // Microsoft.Unity.VisualStudio.Editor was giving an error
    public Slider colorSlider;
    public Slider brightnessSlider;
    private Color originalColor;
    void Start()
    {
        originalColor = backgroundImage.color;
        colorSlider.onValueChanged.AddListener(colorSliderChanged);
        brightnessSlider.onValueChanged.AddListener(brightnessSliderChanged);
    }
    void colorSliderChanged(float value)
    {
        if (value == 0 ^ value == 1) {
            backgroundImage.color = originalColor;
        }
        else {
            Color newColor = Color.Lerp(Color.red, Color.blue, value);
            backgroundImage.color = newColor;
        }
    }
    void brightnessSliderChanged(float value) {
        Color brightness = new Color(255,255,255, value); // white color, set alpha
        brightnessImage.color = brightness;
    }

    public void ToggleFullScreen(bool isFullscreen)
    {

        Screen.fullScreen = isFullscreen;
    }

}

