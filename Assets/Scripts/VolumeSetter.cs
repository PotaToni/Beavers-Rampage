using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] GameObject slider;

    GameObject gameControl;

    private void Start()
    {
        gameControl = FindObjectOfType<GameControl>().gameObject;
        slider.GetComponent<Slider>().value = gameControl.GetComponent<GameControl>().volume;
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        gameControl.GetComponent<GameControl>().volume = volume;
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

}
