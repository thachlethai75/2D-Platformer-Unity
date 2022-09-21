using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvent : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioMixer audioMixer;
    private float value;

    private void Start()
    {
        Time.timeScale = 1;
        audioMixer.GetFloat("volume", out value);
        volumeSlider.value = value;
    }

    public void SetVolume()
    {
        audioMixer.SetFloat("volume", volumeSlider.value);
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
